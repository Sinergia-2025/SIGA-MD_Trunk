<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActivacionesOC
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
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenActivacion")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActivacion")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Contacto")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdObservacion")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaReprogEntrega")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Criticidad")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Items")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidades")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaE")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TelefonoProveedor")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoElectronico")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DetalleObservacion")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcPendiente")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestos")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteBruto")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAutorizacion")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("rn")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePendiente", 0)
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
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivacionesOC))
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.ugeResumen = New Eniac.Win.UltraGridEditable()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.grpVerificaciones = New System.Windows.Forms.GroupBox()
      Me.cmbFechaE = New Eniac.Controles.ComboBox()
      Me.Label10 = New Eniac.Controles.Label()
      Me.cmbPrecios = New Eniac.Controles.ComboBox()
      Me.Label9 = New Eniac.Controles.Label()
      Me.Label8 = New Eniac.Controles.Label()
      Me.cmbCant = New Eniac.Controles.ComboBox()
      Me.Label7 = New Eniac.Controles.Label()
      Me.cmbItems = New Eniac.Controles.ComboBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chkMesCompletoFA = New Eniac.Controles.CheckBox()
      Me.dtpFechaAutorizacionHasta = New Eniac.Controles.DateTimePicker()
      Me.Label14 = New Eniac.Controles.Label()
      Me.dtpFechaAutorizacionDesde = New Eniac.Controles.DateTimePicker()
      Me.Label15 = New Eniac.Controles.Label()
      Me.chbFechaAutorizacion = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.chkMesCompletoFEN = New Eniac.Controles.CheckBox()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbFechaReprogEntrega = New Eniac.Controles.CheckBox()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.chkMesCompletoFRE = New Eniac.Controles.CheckBox()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.dtpFechaRepEntregaHasta = New Eniac.Controles.DateTimePicker()
      Me.Label5 = New Eniac.Controles.Label()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.dtpFechaRepEntregaDesde = New Eniac.Controles.DateTimePicker()
      Me.Label6 = New Eniac.Controles.Label()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.dtpFechaEntregaDesde = New Eniac.Controles.DateTimePicker()
      Me.dtpFechaEntregaHasta = New Eniac.Controles.DateTimePicker()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.cmbObservaciones = New Eniac.Controles.ComboBox()
      Me.chbObservacion = New Eniac.Controles.CheckBox()
      Me.cmbCriticidad = New Eniac.Controles.ComboBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.chbIdPedido = New Eniac.Controles.CheckBox()
      Me.txtIdPedido = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbActivadas = New Eniac.Controles.ComboBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.chbOcultarFiltros = New Eniac.Controles.CheckBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.cmbEstados = New Eniac.Controles.ComboBox()
      Me.chbVerUltimaActivacion = New Eniac.Controles.CheckBox()
      CType(Me.ugeResumen, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      Me.grpVerificaciones.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ugeResumen
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugeResumen.DisplayLayout.Appearance = Appearance1
      Me.ugeResumen.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
      UltraGridColumn1.Header.VisiblePosition = 22
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Tipo"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 42
      UltraGridColumn3.Header.VisiblePosition = 23
      UltraGridColumn3.Hidden = True
      UltraGridColumn4.Header.VisiblePosition = 24
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.Header.Caption = "Orden Compra"
      UltraGridColumn5.Header.VisiblePosition = 2
      UltraGridColumn5.Width = 57
      UltraGridColumn7.Header.Caption = "Item"
      UltraGridColumn7.Header.VisiblePosition = 4
      UltraGridColumn7.Width = 43
      UltraGridColumn8.Header.Caption = "Orden Activacion"
      UltraGridColumn8.Header.VisiblePosition = 25
      UltraGridColumn8.Hidden = True
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn10.CellAppearance = Appearance2
      UltraGridColumn10.Header.Caption = "Fecha Activacion"
      UltraGridColumn10.Header.VisiblePosition = 10
      UltraGridColumn10.Width = 88
      UltraGridColumn11.Header.Caption = "Situación"
      UltraGridColumn11.Header.VisiblePosition = 18
      UltraGridColumn11.Width = 149
      UltraGridColumn12.Header.VisiblePosition = 17
      UltraGridColumn12.Width = 82
      UltraGridColumn13.Header.VisiblePosition = 27
      UltraGridColumn13.Hidden = True
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn14.CellAppearance = Appearance3
      UltraGridColumn14.Header.Caption = "Fecha Reprog Entrega"
      UltraGridColumn14.Header.VisiblePosition = 9
      UltraGridColumn14.Width = 84
      UltraGridColumn15.Header.VisiblePosition = 0
      UltraGridColumn15.Width = 66
      UltraGridColumn16.Header.VisiblePosition = 28
      UltraGridColumn16.Hidden = True
      UltraGridColumn16.Width = 80
      UltraGridColumn17.Header.VisiblePosition = 29
      UltraGridColumn17.Hidden = True
      UltraGridColumn17.Width = 80
      UltraGridColumn18.Header.VisiblePosition = 30
      UltraGridColumn18.Hidden = True
      UltraGridColumn18.Width = 80
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn19.CellAppearance = Appearance4
      UltraGridColumn19.Header.Caption = "Fecha Entreg."
      UltraGridColumn19.Header.VisiblePosition = 31
      UltraGridColumn19.Hidden = True
      UltraGridColumn19.Width = 80
      UltraGridColumn20.Header.Caption = "Teléfono"
      UltraGridColumn20.Header.VisiblePosition = 20
      UltraGridColumn21.Header.Caption = "Correo Electrónico"
      UltraGridColumn21.Header.VisiblePosition = 21
      UltraGridColumn21.Width = 162
      UltraGridColumn22.Header.Caption = "Observación"
      UltraGridColumn22.Header.VisiblePosition = 19
      UltraGridColumn22.Width = 134
      UltraGridColumn23.Header.Caption = "Proveedor"
      UltraGridColumn23.Header.VisiblePosition = 3
      UltraGridColumn23.Width = 134
      UltraGridColumn24.Header.Caption = "Cod. Artículo"
      UltraGridColumn24.Header.VisiblePosition = 5
      UltraGridColumn24.Width = 82
      UltraGridColumn25.Header.Caption = "Usuario"
      UltraGridColumn25.Header.VisiblePosition = 26
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn6.CellAppearance = Appearance5
      UltraGridColumn6.Header.Caption = "Fecha Entrega"
      UltraGridColumn6.Header.VisiblePosition = 8
      UltraGridColumn6.Width = 92
      UltraGridColumn9.Header.Caption = "Descripción Artículo"
      UltraGridColumn9.Header.VisiblePosition = 6
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn26.CellAppearance = Appearance6
      UltraGridColumn26.Format = "N2"
      UltraGridColumn26.Header.Caption = "% Pendiente"
      UltraGridColumn26.Header.VisiblePosition = 15
      UltraGridColumn26.Width = 75
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn27.CellAppearance = Appearance7
      UltraGridColumn27.Format = "N2"
      UltraGridColumn27.Header.Caption = "Total con IVA"
      UltraGridColumn27.Header.VisiblePosition = 14
      UltraGridColumn27.Width = 100
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn29.CellAppearance = Appearance8
      UltraGridColumn29.Format = "N2"
      UltraGridColumn29.Header.Caption = "IVA"
      UltraGridColumn29.Header.VisiblePosition = 13
      UltraGridColumn29.Width = 100
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn30.CellAppearance = Appearance9
      UltraGridColumn30.Format = "N2"
      UltraGridColumn30.Header.Caption = "Total Neto"
      UltraGridColumn30.Header.VisiblePosition = 12
      UltraGridColumn30.Width = 100
      Appearance10.TextHAlignAsString = "Center"
      UltraGridColumn31.CellAppearance = Appearance10
      UltraGridColumn31.Header.Caption = "Fecha Envío"
      UltraGridColumn31.Header.VisiblePosition = 11
      UltraGridColumn31.Width = 92
      Appearance11.TextHAlignAsString = "Center"
      UltraGridColumn32.CellAppearance = Appearance11
      UltraGridColumn32.Header.Caption = "Fecha Autorización"
      UltraGridColumn32.Header.VisiblePosition = 7
      UltraGridColumn32.Width = 92
      UltraGridColumn33.Header.VisiblePosition = 32
      UltraGridColumn33.Hidden = True
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn28.CellAppearance = Appearance12
      UltraGridColumn28.DataType = GetType(Decimal)
      UltraGridColumn28.Format = "N2"
      UltraGridColumn28.Header.Caption = "Importe Pendiente"
      UltraGridColumn28.Header.VisiblePosition = 16
      UltraGridColumn28.Width = 80
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn7, UltraGridColumn8, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn6, UltraGridColumn9, UltraGridColumn26, UltraGridColumn27, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn28})
      Me.ugeResumen.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugeResumen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugeResumen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugeResumen.DisplayLayout.GroupByBox.Appearance = Appearance13
      Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugeResumen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance14
      Me.ugeResumen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance15.BackColor2 = System.Drawing.SystemColors.Control
      Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugeResumen.DisplayLayout.GroupByBox.PromptAppearance = Appearance15
      Me.ugeResumen.DisplayLayout.MaxColScrollRegions = 1
      Me.ugeResumen.DisplayLayout.MaxRowScrollRegions = 1
      Appearance16.BackColor = System.Drawing.SystemColors.Window
      Appearance16.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugeResumen.DisplayLayout.Override.ActiveCellAppearance = Appearance16
      Appearance17.BackColor = System.Drawing.SystemColors.Highlight
      Appearance17.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugeResumen.DisplayLayout.Override.ActiveRowAppearance = Appearance17
      Me.ugeResumen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugeResumen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugeResumen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance18.BackColor = System.Drawing.SystemColors.Window
      Me.ugeResumen.DisplayLayout.Override.CardAreaAppearance = Appearance18
      Appearance19.BorderColor = System.Drawing.Color.Silver
      Appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugeResumen.DisplayLayout.Override.CellAppearance = Appearance19
      Me.ugeResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugeResumen.DisplayLayout.Override.CellPadding = 0
      Appearance20.BackColor = System.Drawing.SystemColors.Control
      Appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance20.BorderColor = System.Drawing.SystemColors.Window
      Me.ugeResumen.DisplayLayout.Override.GroupByRowAppearance = Appearance20
      Appearance21.TextHAlignAsString = "Left"
      Me.ugeResumen.DisplayLayout.Override.HeaderAppearance = Appearance21
      Me.ugeResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugeResumen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance22.BackColor = System.Drawing.SystemColors.Window
      Appearance22.BorderColor = System.Drawing.Color.Silver
      Me.ugeResumen.DisplayLayout.Override.RowAppearance = Appearance22
      Me.ugeResumen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance23.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugeResumen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance23
      Me.ugeResumen.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugeResumen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugeResumen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugeResumen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugeResumen.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugeResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugeResumen.Location = New System.Drawing.Point(0, 0)
      Me.ugeResumen.Name = "ugeResumen"
      Me.ugeResumen.Size = New System.Drawing.Size(861, 264)
      Me.ugeResumen.TabIndex = 4
      Me.ugeResumen.Text = "UltraGridEditable1"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(885, 29)
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
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 506)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(885, 22)
      Me.stsStado.TabIndex = 6
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(806, 17)
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
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.grpVerificaciones)
      Me.grbConsultar.Controls.Add(Me.bscProducto2)
      Me.grbConsultar.Controls.Add(Me.bscCodigoProducto2)
      Me.grbConsultar.Controls.Add(Me.chbProducto)
      Me.grbConsultar.Controls.Add(Me.GroupBox1)
      Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
      Me.grbConsultar.Controls.Add(Me.cmbObservaciones)
      Me.grbConsultar.Controls.Add(Me.chbObservacion)
      Me.grbConsultar.Controls.Add(Me.cmbCriticidad)
      Me.grbConsultar.Controls.Add(Me.Label4)
      Me.grbConsultar.Controls.Add(Me.chbIdPedido)
      Me.grbConsultar.Controls.Add(Me.txtIdPedido)
      Me.grbConsultar.Controls.Add(Me.Label1)
      Me.grbConsultar.Controls.Add(Me.cmbActivadas)
      Me.grbConsultar.Controls.Add(Me.chkExpandAll)
      Me.grbConsultar.Controls.Add(Me.cmbUsuario)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
      Me.grbConsultar.Controls.Add(Me.bscProveedor)
      Me.grbConsultar.Controls.Add(Me.chbProveedor)
      Me.grbConsultar.Controls.Add(Me.chbUsuario)
      Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Fill
      Me.grbConsultar.Location = New System.Drawing.Point(0, 0)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(861, 180)
      Me.grbConsultar.TabIndex = 7
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Filtros"
      '
      'grpVerificaciones
      '
      Me.grpVerificaciones.Controls.Add(Me.cmbFechaE)
      Me.grpVerificaciones.Controls.Add(Me.cmbPrecios)
      Me.grpVerificaciones.Controls.Add(Me.Label8)
      Me.grpVerificaciones.Controls.Add(Me.cmbCant)
      Me.grpVerificaciones.Controls.Add(Me.Label7)
      Me.grpVerificaciones.Controls.Add(Me.cmbItems)
      Me.grpVerificaciones.Controls.Add(Me.Label10)
      Me.grpVerificaciones.Controls.Add(Me.Label9)
      Me.grpVerificaciones.Location = New System.Drawing.Point(698, 8)
      Me.grpVerificaciones.Name = "grpVerificaciones"
      Me.grpVerificaciones.Size = New System.Drawing.Size(155, 106)
      Me.grpVerificaciones.TabIndex = 102
      Me.grpVerificaciones.TabStop = False
      Me.grpVerificaciones.Text = "Verificaciones"
      '
      'cmbFechaE
      '
      Me.cmbFechaE.BindearPropiedadControl = ""
      Me.cmbFechaE.BindearPropiedadEntidad = ""
      Me.cmbFechaE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFechaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFechaE.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFechaE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFechaE.FormattingEnabled = True
      Me.cmbFechaE.IsPK = False
      Me.cmbFechaE.IsRequired = False
      Me.cmbFechaE.Items.AddRange(New Object() {"Todas", "Ok", "No Ok"})
      Me.cmbFechaE.Key = Nothing
      Me.cmbFechaE.LabelAsoc = Me.Label10
      Me.cmbFechaE.Location = New System.Drawing.Point(76, 81)
      Me.cmbFechaE.Name = "cmbFechaE"
      Me.cmbFechaE.Size = New System.Drawing.Size(76, 21)
      Me.cmbFechaE.TabIndex = 34
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.LabelAsoc = Nothing
      Me.Label10.Location = New System.Drawing.Point(1, 85)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(77, 13)
      Me.Label10.TabIndex = 33
      Me.Label10.Text = "Fecha Entrega"
      '
      'cmbPrecios
      '
      Me.cmbPrecios.BindearPropiedadControl = ""
      Me.cmbPrecios.BindearPropiedadEntidad = ""
      Me.cmbPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPrecios.FormattingEnabled = True
      Me.cmbPrecios.IsPK = False
      Me.cmbPrecios.IsRequired = False
      Me.cmbPrecios.Items.AddRange(New Object() {"Todos", "Ok", "No Ok"})
      Me.cmbPrecios.Key = Nothing
      Me.cmbPrecios.LabelAsoc = Me.Label9
      Me.cmbPrecios.Location = New System.Drawing.Point(76, 59)
      Me.cmbPrecios.Name = "cmbPrecios"
      Me.cmbPrecios.Size = New System.Drawing.Size(76, 21)
      Me.cmbPrecios.TabIndex = 32
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(1, 63)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(76, 13)
      Me.Label9.TabIndex = 31
      Me.Label9.Text = "Precio Unitario"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.LabelAsoc = Nothing
      Me.Label8.Location = New System.Drawing.Point(1, 41)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(60, 13)
      Me.Label8.TabIndex = 29
      Me.Label8.Text = "Cantidades"
      '
      'cmbCant
      '
      Me.cmbCant.BindearPropiedadControl = ""
      Me.cmbCant.BindearPropiedadEntidad = ""
      Me.cmbCant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCant.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCant.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCant.FormattingEnabled = True
      Me.cmbCant.IsPK = False
      Me.cmbCant.IsRequired = False
      Me.cmbCant.Items.AddRange(New Object() {"Todas", "Ok", "No Ok"})
      Me.cmbCant.Key = Nothing
      Me.cmbCant.LabelAsoc = Me.Label8
      Me.cmbCant.Location = New System.Drawing.Point(76, 37)
      Me.cmbCant.Name = "cmbCant"
      Me.cmbCant.Size = New System.Drawing.Size(76, 21)
      Me.cmbCant.TabIndex = 30
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.LabelAsoc = Nothing
      Me.Label7.Location = New System.Drawing.Point(2, 18)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(32, 13)
      Me.Label7.TabIndex = 27
      Me.Label7.Text = "Items"
      '
      'cmbItems
      '
      Me.cmbItems.BindearPropiedadControl = ""
      Me.cmbItems.BindearPropiedadEntidad = ""
      Me.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbItems.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbItems.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbItems.FormattingEnabled = True
      Me.cmbItems.IsPK = False
      Me.cmbItems.IsRequired = False
      Me.cmbItems.Items.AddRange(New Object() {"Todos", "Ok", "No Ok"})
      Me.cmbItems.Key = Nothing
      Me.cmbItems.LabelAsoc = Me.Label7
      Me.cmbItems.Location = New System.Drawing.Point(76, 14)
      Me.cmbItems.Name = "cmbItems"
      Me.cmbItems.Size = New System.Drawing.Size(76, 21)
      Me.cmbItems.TabIndex = 28
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
      Me.bscProducto2.Location = New System.Drawing.Point(508, 154)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(232, 20)
      Me.bscProducto2.TabIndex = 101
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
      Me.chbProducto.Location = New System.Drawing.Point(345, 157)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 99
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
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(417, 154)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoProducto2.TabIndex = 100
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chkMesCompletoFA)
      Me.GroupBox1.Controls.Add(Me.dtpFechaAutorizacionHasta)
      Me.GroupBox1.Controls.Add(Me.dtpFechaAutorizacionDesde)
      Me.GroupBox1.Controls.Add(Me.Label14)
      Me.GroupBox1.Controls.Add(Me.Label15)
      Me.GroupBox1.Controls.Add(Me.chbFechaAutorizacion)
      Me.GroupBox1.Controls.Add(Me.chkMesCompleto)
      Me.GroupBox1.Controls.Add(Me.chkMesCompletoFEN)
      Me.GroupBox1.Controls.Add(Me.lblDesde)
      Me.GroupBox1.Controls.Add(Me.chbFechaReprogEntrega)
      Me.GroupBox1.Controls.Add(Me.lblHasta)
      Me.GroupBox1.Controls.Add(Me.chkMesCompletoFRE)
      Me.GroupBox1.Controls.Add(Me.dtpDesde)
      Me.GroupBox1.Controls.Add(Me.dtpFechaRepEntregaHasta)
      Me.GroupBox1.Controls.Add(Me.dtpHasta)
      Me.GroupBox1.Controls.Add(Me.dtpFechaRepEntregaDesde)
      Me.GroupBox1.Controls.Add(Me.chbFecha)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Controls.Add(Me.chbFechaEntrega)
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.dtpFechaEntregaDesde)
      Me.GroupBox1.Controls.Add(Me.dtpFechaEntregaHasta)
      Me.GroupBox1.Location = New System.Drawing.Point(172, 8)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(520, 117)
      Me.GroupBox1.TabIndex = 98
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Filtros Fechas"
      '
      'chkMesCompletoFA
      '
      Me.chkMesCompletoFA.AutoSize = True
      Me.chkMesCompletoFA.BindearPropiedadControl = Nothing
      Me.chkMesCompletoFA.BindearPropiedadEntidad = Nothing
      Me.chkMesCompletoFA.Enabled = False
      Me.chkMesCompletoFA.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompletoFA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompletoFA.IsPK = False
      Me.chkMesCompletoFA.IsRequired = False
      Me.chkMesCompletoFA.Key = Nothing
      Me.chkMesCompletoFA.LabelAsoc = Nothing
      Me.chkMesCompletoFA.Location = New System.Drawing.Point(118, 91)
      Me.chkMesCompletoFA.Name = "chkMesCompletoFA"
      Me.chkMesCompletoFA.Size = New System.Drawing.Size(59, 17)
      Me.chkMesCompletoFA.TabIndex = 103
      Me.chkMesCompletoFA.Text = "Mes C."
      Me.chkMesCompletoFA.UseVisualStyleBackColor = True
      '
      'dtpFechaAutorizacionHasta
      '
      Me.dtpFechaAutorizacionHasta.BindearPropiedadControl = Nothing
      Me.dtpFechaAutorizacionHasta.BindearPropiedadEntidad = Nothing
      Me.dtpFechaAutorizacionHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaAutorizacionHasta.Enabled = False
      Me.dtpFechaAutorizacionHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAutorizacionHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAutorizacionHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAutorizacionHasta.IsPK = False
      Me.dtpFechaAutorizacionHasta.IsRequired = False
      Me.dtpFechaAutorizacionHasta.Key = ""
      Me.dtpFechaAutorizacionHasta.LabelAsoc = Me.Label14
      Me.dtpFechaAutorizacionHasta.Location = New System.Drawing.Point(385, 89)
      Me.dtpFechaAutorizacionHasta.Name = "dtpFechaAutorizacionHasta"
      Me.dtpFechaAutorizacionHasta.Size = New System.Drawing.Size(128, 20)
      Me.dtpFechaAutorizacionHasta.TabIndex = 102
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.LabelAsoc = Nothing
      Me.Label14.Location = New System.Drawing.Point(344, 93)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(35, 13)
      Me.Label14.TabIndex = 101
      Me.Label14.Text = "Hasta"
      '
      'dtpFechaAutorizacionDesde
      '
      Me.dtpFechaAutorizacionDesde.BindearPropiedadControl = Nothing
      Me.dtpFechaAutorizacionDesde.BindearPropiedadEntidad = Nothing
      Me.dtpFechaAutorizacionDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaAutorizacionDesde.Enabled = False
      Me.dtpFechaAutorizacionDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAutorizacionDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAutorizacionDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAutorizacionDesde.IsPK = False
      Me.dtpFechaAutorizacionDesde.IsRequired = False
      Me.dtpFechaAutorizacionDesde.Key = ""
      Me.dtpFechaAutorizacionDesde.LabelAsoc = Me.Label15
      Me.dtpFechaAutorizacionDesde.Location = New System.Drawing.Point(213, 89)
      Me.dtpFechaAutorizacionDesde.Name = "dtpFechaAutorizacionDesde"
      Me.dtpFechaAutorizacionDesde.Size = New System.Drawing.Size(129, 20)
      Me.dtpFechaAutorizacionDesde.TabIndex = 100
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.LabelAsoc = Nothing
      Me.Label15.Location = New System.Drawing.Point(174, 92)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(38, 13)
      Me.Label15.TabIndex = 99
      Me.Label15.Text = "Desde"
      '
      'chbFechaAutorizacion
      '
      Me.chbFechaAutorizacion.AutoSize = True
      Me.chbFechaAutorizacion.BindearPropiedadControl = Nothing
      Me.chbFechaAutorizacion.BindearPropiedadEntidad = Nothing
      Me.chbFechaAutorizacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaAutorizacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaAutorizacion.IsPK = False
      Me.chbFechaAutorizacion.IsRequired = False
      Me.chbFechaAutorizacion.Key = Nothing
      Me.chbFechaAutorizacion.LabelAsoc = Nothing
      Me.chbFechaAutorizacion.Location = New System.Drawing.Point(5, 91)
      Me.chbFechaAutorizacion.Name = "chbFechaAutorizacion"
      Me.chbFechaAutorizacion.Size = New System.Drawing.Size(117, 17)
      Me.chbFechaAutorizacion.TabIndex = 98
      Me.chbFechaAutorizacion.Text = "Fecha Autorización"
      Me.chbFechaAutorizacion.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(118, 21)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
      Me.chkMesCompleto.TabIndex = 3
      Me.chkMesCompleto.Text = "Mes C."
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'chkMesCompletoFEN
      '
      Me.chkMesCompletoFEN.AutoSize = True
      Me.chkMesCompletoFEN.BindearPropiedadControl = Nothing
      Me.chkMesCompletoFEN.BindearPropiedadEntidad = Nothing
      Me.chkMesCompletoFEN.Enabled = False
      Me.chkMesCompletoFEN.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompletoFEN.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompletoFEN.IsPK = False
      Me.chkMesCompletoFEN.IsRequired = False
      Me.chkMesCompletoFEN.Key = Nothing
      Me.chkMesCompletoFEN.LabelAsoc = Nothing
      Me.chkMesCompletoFEN.Location = New System.Drawing.Point(118, 45)
      Me.chkMesCompletoFEN.Name = "chkMesCompletoFEN"
      Me.chkMesCompletoFEN.Size = New System.Drawing.Size(59, 17)
      Me.chkMesCompletoFEN.TabIndex = 97
      Me.chkMesCompletoFEN.Text = "Mes C."
      Me.chkMesCompletoFEN.UseVisualStyleBackColor = True
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(175, 22)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 4
      Me.lblDesde.Text = "Desde"
      '
      'chbFechaReprogEntrega
      '
      Me.chbFechaReprogEntrega.AutoSize = True
      Me.chbFechaReprogEntrega.BindearPropiedadControl = Nothing
      Me.chbFechaReprogEntrega.BindearPropiedadEntidad = Nothing
      Me.chbFechaReprogEntrega.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaReprogEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaReprogEntrega.IsPK = False
      Me.chbFechaReprogEntrega.IsRequired = False
      Me.chbFechaReprogEntrega.Key = Nothing
      Me.chbFechaReprogEntrega.LabelAsoc = Nothing
      Me.chbFechaReprogEntrega.Location = New System.Drawing.Point(5, 69)
      Me.chbFechaReprogEntrega.Name = "chbFechaReprogEntrega"
      Me.chbFechaReprogEntrega.Size = New System.Drawing.Size(110, 17)
      Me.chbFechaReprogEntrega.TabIndex = 91
      Me.chbFechaReprogEntrega.Text = "Fecha R. Entrega"
      Me.chbFechaReprogEntrega.UseVisualStyleBackColor = True
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(348, 23)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 6
      Me.lblHasta.Text = "Hasta"
      '
      'chkMesCompletoFRE
      '
      Me.chkMesCompletoFRE.AutoSize = True
      Me.chkMesCompletoFRE.BindearPropiedadControl = Nothing
      Me.chkMesCompletoFRE.BindearPropiedadEntidad = Nothing
      Me.chkMesCompletoFRE.Enabled = False
      Me.chkMesCompletoFRE.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompletoFRE.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompletoFRE.IsPK = False
      Me.chkMesCompletoFRE.IsRequired = False
      Me.chkMesCompletoFRE.Key = Nothing
      Me.chkMesCompletoFRE.LabelAsoc = Nothing
      Me.chkMesCompletoFRE.Location = New System.Drawing.Point(118, 68)
      Me.chkMesCompletoFRE.Name = "chkMesCompletoFRE"
      Me.chkMesCompletoFRE.Size = New System.Drawing.Size(59, 17)
      Me.chkMesCompletoFRE.TabIndex = 92
      Me.chkMesCompletoFRE.Text = "Mes C."
      Me.chkMesCompletoFRE.UseVisualStyleBackColor = True
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
      Me.dtpDesde.Location = New System.Drawing.Point(213, 18)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(128, 20)
      Me.dtpDesde.TabIndex = 5
      '
      'dtpFechaRepEntregaHasta
      '
      Me.dtpFechaRepEntregaHasta.BindearPropiedadControl = Nothing
      Me.dtpFechaRepEntregaHasta.BindearPropiedadEntidad = Nothing
      Me.dtpFechaRepEntregaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaRepEntregaHasta.Enabled = False
      Me.dtpFechaRepEntregaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaRepEntregaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaRepEntregaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaRepEntregaHasta.IsPK = False
      Me.dtpFechaRepEntregaHasta.IsRequired = False
      Me.dtpFechaRepEntregaHasta.Key = ""
      Me.dtpFechaRepEntregaHasta.LabelAsoc = Me.Label5
      Me.dtpFechaRepEntregaHasta.Location = New System.Drawing.Point(383, 66)
      Me.dtpFechaRepEntregaHasta.Name = "dtpFechaRepEntregaHasta"
      Me.dtpFechaRepEntregaHasta.Size = New System.Drawing.Size(129, 20)
      Me.dtpFechaRepEntregaHasta.TabIndex = 96
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.LabelAsoc = Nothing
      Me.Label5.Location = New System.Drawing.Point(347, 70)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(35, 13)
      Me.Label5.TabIndex = 95
      Me.Label5.Text = "Hasta"
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
      Me.dtpHasta.Location = New System.Drawing.Point(384, 19)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
      Me.dtpHasta.TabIndex = 7
      '
      'dtpFechaRepEntregaDesde
      '
      Me.dtpFechaRepEntregaDesde.BindearPropiedadControl = Nothing
      Me.dtpFechaRepEntregaDesde.BindearPropiedadEntidad = Nothing
      Me.dtpFechaRepEntregaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaRepEntregaDesde.Enabled = False
      Me.dtpFechaRepEntregaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaRepEntregaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaRepEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaRepEntregaDesde.IsPK = False
      Me.dtpFechaRepEntregaDesde.IsRequired = False
      Me.dtpFechaRepEntregaDesde.Key = ""
      Me.dtpFechaRepEntregaDesde.LabelAsoc = Me.Label6
      Me.dtpFechaRepEntregaDesde.Location = New System.Drawing.Point(213, 65)
      Me.dtpFechaRepEntregaDesde.Name = "dtpFechaRepEntregaDesde"
      Me.dtpFechaRepEntregaDesde.Size = New System.Drawing.Size(128, 20)
      Me.dtpFechaRepEntregaDesde.TabIndex = 94
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.LabelAsoc = Nothing
      Me.Label6.Location = New System.Drawing.Point(174, 69)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(38, 13)
      Me.Label6.TabIndex = 93
      Me.Label6.Text = "Desde"
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
      Me.chbFecha.Location = New System.Drawing.Point(5, 21)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(73, 17)
      Me.chbFecha.TabIndex = 2
      Me.chbFecha.Text = "Fecha AC"
      Me.chbFecha.UseVisualStyleBackColor = True
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
      Me.chbFechaEntrega.Location = New System.Drawing.Point(5, 45)
      Me.chbFechaEntrega.Name = "chbFechaEntrega"
      Me.chbFechaEntrega.Size = New System.Drawing.Size(96, 17)
      Me.chbFechaEntrega.TabIndex = 27
      Me.chbFechaEntrega.Text = "Fecha Entrega"
      Me.chbFechaEntrega.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(175, 46)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(38, 13)
      Me.Label3.TabIndex = 28
      Me.Label3.Text = "Desde"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(348, 47)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(35, 13)
      Me.Label2.TabIndex = 30
      Me.Label2.Text = "Hasta"
      '
      'dtpFechaEntregaDesde
      '
      Me.dtpFechaEntregaDesde.BindearPropiedadControl = Nothing
      Me.dtpFechaEntregaDesde.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEntregaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaEntregaDesde.Enabled = False
      Me.dtpFechaEntregaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEntregaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEntregaDesde.IsPK = False
      Me.dtpFechaEntregaDesde.IsRequired = False
      Me.dtpFechaEntregaDesde.Key = ""
      Me.dtpFechaEntregaDesde.LabelAsoc = Me.Label3
      Me.dtpFechaEntregaDesde.Location = New System.Drawing.Point(213, 42)
      Me.dtpFechaEntregaDesde.Name = "dtpFechaEntregaDesde"
      Me.dtpFechaEntregaDesde.Size = New System.Drawing.Size(128, 20)
      Me.dtpFechaEntregaDesde.TabIndex = 29
      '
      'dtpFechaEntregaHasta
      '
      Me.dtpFechaEntregaHasta.BindearPropiedadControl = Nothing
      Me.dtpFechaEntregaHasta.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEntregaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaEntregaHasta.Enabled = False
      Me.dtpFechaEntregaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEntregaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEntregaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEntregaHasta.IsPK = False
      Me.dtpFechaEntregaHasta.IsRequired = False
      Me.dtpFechaEntregaHasta.Key = ""
      Me.dtpFechaEntregaHasta.LabelAsoc = Me.Label2
      Me.dtpFechaEntregaHasta.Location = New System.Drawing.Point(384, 42)
      Me.dtpFechaEntregaHasta.Name = "dtpFechaEntregaHasta"
      Me.dtpFechaEntregaHasta.Size = New System.Drawing.Size(128, 20)
      Me.dtpFechaEntregaHasta.TabIndex = 31
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
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(83, 72)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(84, 21)
      Me.cmbTiposComprobantes.TabIndex = 90
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.LabelAsoc = Nothing
      Me.lblTipoComprobante.Location = New System.Drawing.Point(1, 76)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(76, 13)
      Me.lblTipoComprobante.TabIndex = 89
      Me.lblTipoComprobante.Text = "Tipo Comprob."
      '
      'cmbObservaciones
      '
      Me.cmbObservaciones.BindearPropiedadControl = ""
      Me.cmbObservaciones.BindearPropiedadEntidad = ""
      Me.cmbObservaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbObservaciones.Enabled = False
      Me.cmbObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbObservaciones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbObservaciones.FormattingEnabled = True
      Me.cmbObservaciones.IsPK = False
      Me.cmbObservaciones.IsRequired = False
      Me.cmbObservaciones.Items.AddRange(New Object() {"Normal", "Crítica"})
      Me.cmbObservaciones.Key = Nothing
      Me.cmbObservaciones.LabelAsoc = Nothing
      Me.cmbObservaciones.Location = New System.Drawing.Point(103, 131)
      Me.cmbObservaciones.Name = "cmbObservaciones"
      Me.cmbObservaciones.Size = New System.Drawing.Size(228, 21)
      Me.cmbObservaciones.TabIndex = 88
      '
      'chbObservacion
      '
      Me.chbObservacion.AutoSize = True
      Me.chbObservacion.BindearPropiedadControl = Nothing
      Me.chbObservacion.BindearPropiedadEntidad = Nothing
      Me.chbObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbObservacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbObservacion.IsPK = False
      Me.chbObservacion.IsRequired = False
      Me.chbObservacion.Key = Nothing
      Me.chbObservacion.LabelAsoc = Nothing
      Me.chbObservacion.Location = New System.Drawing.Point(9, 132)
      Me.chbObservacion.Name = "chbObservacion"
      Me.chbObservacion.Size = New System.Drawing.Size(97, 17)
      Me.chbObservacion.TabIndex = 87
      Me.chbObservacion.Text = "Observaciones"
      Me.chbObservacion.UseVisualStyleBackColor = True
      '
      'cmbCriticidad
      '
      Me.cmbCriticidad.BindearPropiedadControl = "SelectedItem"
      Me.cmbCriticidad.BindearPropiedadEntidad = "Criticidad"
      Me.cmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCriticidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCriticidad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCriticidad.FormattingEnabled = True
      Me.cmbCriticidad.IsPK = False
      Me.cmbCriticidad.IsRequired = True
      Me.cmbCriticidad.Items.AddRange(New Object() {"Todas", "Normal", "Crítica"})
      Me.cmbCriticidad.Key = Nothing
      Me.cmbCriticidad.LabelAsoc = Nothing
      Me.cmbCriticidad.Location = New System.Drawing.Point(84, 46)
      Me.cmbCriticidad.Name = "cmbCriticidad"
      Me.cmbCriticidad.Size = New System.Drawing.Size(83, 21)
      Me.cmbCriticidad.TabIndex = 33
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(2, 49)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 32
      Me.Label4.Text = "Criticidad"
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
      Me.chbIdPedido.Location = New System.Drawing.Point(9, 107)
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
      Me.txtIdPedido.Location = New System.Drawing.Point(83, 105)
      Me.txtIdPedido.MaxLength = 8
      Me.txtIdPedido.Name = "txtIdPedido"
      Me.txtIdPedido.Size = New System.Drawing.Size(83, 20)
      Me.txtIdPedido.TabIndex = 11
      Me.txtIdPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(2, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(68, 13)
      Me.Label1.TabIndex = 25
      Me.Label1.Text = "Activaciones"
      '
      'cmbActivadas
      '
      Me.cmbActivadas.BindearPropiedadControl = ""
      Me.cmbActivadas.BindearPropiedadEntidad = ""
      Me.cmbActivadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbActivadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbActivadas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbActivadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbActivadas.FormattingEnabled = True
      Me.cmbActivadas.IsPK = False
      Me.cmbActivadas.IsRequired = False
      Me.cmbActivadas.Items.AddRange(New Object() {"Todas", "Cabecera", "Detalle"})
      Me.cmbActivadas.Key = Nothing
      Me.cmbActivadas.LabelAsoc = Me.Label1
      Me.cmbActivadas.Location = New System.Drawing.Point(84, 21)
      Me.cmbActivadas.Name = "cmbActivadas"
      Me.cmbActivadas.Size = New System.Drawing.Size(83, 21)
      Me.cmbActivadas.TabIndex = 26
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(749, 165)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
      Me.chkExpandAll.TabIndex = 24
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'cmbUsuario
      '
      Me.cmbUsuario.BindearPropiedadControl = Nothing
      Me.cmbUsuario.BindearPropiedadEntidad = Nothing
      Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuario.Enabled = False
      Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuario.FormattingEnabled = True
      Me.cmbUsuario.IsPK = False
      Me.cmbUsuario.IsRequired = False
      Me.cmbUsuario.Key = Nothing
      Me.cmbUsuario.LabelAsoc = Nothing
      Me.cmbUsuario.Location = New System.Drawing.Point(83, 157)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(128, 21)
      Me.cmbUsuario.TabIndex = 20
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(748, 118)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(104, 45)
      Me.btnConsultar.TabIndex = 23
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.AyudaAncho = 608
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
      Me.bscCodigoProveedor.ColumnasAncho = Nothing
      Me.bscCodigoProveedor.ColumnasFormato = Nothing
      Me.bscCodigoProveedor.ColumnasOcultas = Nothing
      Me.bscCodigoProveedor.ColumnasTitulos = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.Enabled = False
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = False
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Nothing
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(417, 128)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 13
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'bscProveedor
      '
      Me.bscProveedor.AutoSize = True
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.Enabled = False
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
      Me.bscProveedor.Location = New System.Drawing.Point(508, 128)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(232, 23)
      Me.bscProveedor.TabIndex = 16
      Me.bscProveedor.Titulo = Nothing
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
      Me.chbProveedor.Location = New System.Drawing.Point(345, 130)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 12
      Me.chbProveedor.Text = "Proveedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
      '
      'chbUsuario
      '
      Me.chbUsuario.AutoSize = True
      Me.chbUsuario.BindearPropiedadControl = Nothing
      Me.chbUsuario.BindearPropiedadEntidad = Nothing
      Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuario.IsPK = False
      Me.chbUsuario.IsRequired = False
      Me.chbUsuario.Key = Nothing
      Me.chbUsuario.LabelAsoc = Nothing
      Me.chbUsuario.Location = New System.Drawing.Point(8, 159)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 19
      Me.chbUsuario.Text = "Usuario"
      Me.chbUsuario.UseVisualStyleBackColor = True
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugeResumen
      Appearance24.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance24
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
      'SplitContainer1
      '
      Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.SplitContainer1.Location = New System.Drawing.Point(12, 55)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.grbConsultar)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.ugeResumen)
      Me.SplitContainer1.Size = New System.Drawing.Size(861, 448)
      Me.SplitContainer1.SplitterDistance = 180
      Me.SplitContainer1.TabIndex = 103
      '
      'chbOcultarFiltros
      '
      Me.chbOcultarFiltros.AutoSize = True
      Me.chbOcultarFiltros.BindearPropiedadControl = Nothing
      Me.chbOcultarFiltros.BindearPropiedadEntidad = Nothing
      Me.chbOcultarFiltros.Checked = True
      Me.chbOcultarFiltros.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbOcultarFiltros.ForeColorFocus = System.Drawing.Color.Red
      Me.chbOcultarFiltros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbOcultarFiltros.IsPK = False
      Me.chbOcultarFiltros.IsRequired = False
      Me.chbOcultarFiltros.Key = Nothing
      Me.chbOcultarFiltros.LabelAsoc = Nothing
      Me.chbOcultarFiltros.Location = New System.Drawing.Point(12, 34)
      Me.chbOcultarFiltros.Name = "chbOcultarFiltros"
      Me.chbOcultarFiltros.Size = New System.Drawing.Size(72, 17)
      Me.chbOcultarFiltros.TabIndex = 104
      Me.chbOcultarFiltros.Text = "Ver Filtros"
      Me.chbOcultarFiltros.UseVisualStyleBackColor = True
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(98, 36)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(80, 13)
      Me.lblEstado.TabIndex = 105
      Me.lblEstado.Text = "Estado Artículo"
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
      Me.cmbEstados.LabelAsoc = Me.lblEstado
      Me.cmbEstados.Location = New System.Drawing.Point(178, 32)
      Me.cmbEstados.Name = "cmbEstados"
      Me.cmbEstados.Size = New System.Drawing.Size(169, 21)
      Me.cmbEstados.TabIndex = 106
      '
      'chbVerUltimaActivacion
      '
      Me.chbVerUltimaActivacion.AutoSize = True
      Me.chbVerUltimaActivacion.BindearPropiedadControl = Nothing
      Me.chbVerUltimaActivacion.BindearPropiedadEntidad = Nothing
      Me.chbVerUltimaActivacion.Checked = True
      Me.chbVerUltimaActivacion.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbVerUltimaActivacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVerUltimaActivacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVerUltimaActivacion.IsPK = False
      Me.chbVerUltimaActivacion.IsRequired = False
      Me.chbVerUltimaActivacion.Key = Nothing
      Me.chbVerUltimaActivacion.LabelAsoc = Nothing
      Me.chbVerUltimaActivacion.Location = New System.Drawing.Point(373, 35)
      Me.chbVerUltimaActivacion.Name = "chbVerUltimaActivacion"
      Me.chbVerUltimaActivacion.Size = New System.Drawing.Size(125, 17)
      Me.chbVerUltimaActivacion.TabIndex = 107
      Me.chbVerUltimaActivacion.Text = "Ver última Activación"
      Me.chbVerUltimaActivacion.UseVisualStyleBackColor = True
      '
      'ActivacionesOC
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(885, 528)
      Me.Controls.Add(Me.chbVerUltimaActivacion)
      Me.Controls.Add(Me.lblEstado)
      Me.Controls.Add(Me.cmbEstados)
      Me.Controls.Add(Me.chbOcultarFiltros)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ActivacionesOC"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Activaciones de Ordenes de Compra"
      CType(Me.ugeResumen, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.grpVerificaciones.ResumeLayout(False)
      Me.grpVerificaciones.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents ugeResumen As UltraGridEditable
   Public WithEvents tstBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Private WithEvents ToolStripSeparator1 As ToolStripSeparator
   Private WithEvents toolStripSeparator3 As ToolStripSeparator
   Public WithEvents tsbSalir As ToolStripButton
   Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As ToolStripProgressBar
   Protected WithEvents tssRegistros As ToolStripStatusLabel
   Friend WithEvents grbConsultar As GroupBox
   Friend WithEvents chbIdPedido As Controles.CheckBox
   Friend WithEvents txtIdPedido As Controles.TextBox
   Friend WithEvents dtpFechaEntregaHasta As Controles.DateTimePicker
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents dtpFechaEntregaDesde As Controles.DateTimePicker
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents chbFechaEntrega As Controles.CheckBox
   Friend WithEvents chbFecha As Controles.CheckBox
   Friend WithEvents chkExpandAll As CheckBox
   Friend WithEvents chbUsuario As Controles.CheckBox
   Friend WithEvents cmbUsuario As Controles.ComboBox
   Friend WithEvents btnConsultar As Controles.Button
   Friend WithEvents bscCodigoProveedor As Controles.Buscador
   Friend WithEvents bscProveedor As Controles.Buscador
   Friend WithEvents chbProveedor As Controles.CheckBox
   Friend WithEvents chkMesCompleto As Controles.CheckBox
   Friend WithEvents dtpHasta As Controles.DateTimePicker
   Friend WithEvents lblHasta As Controles.Label
   Friend WithEvents dtpDesde As Controles.DateTimePicker
   Friend WithEvents lblDesde As Controles.Label
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents cmbActivadas As Controles.ComboBox
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents cmbCriticidad As Controles.ComboBox
   Friend WithEvents chbObservacion As Controles.CheckBox
   Friend WithEvents tsbImprimir As ToolStripButton
   Friend WithEvents tsddExportar As ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As ToolStripMenuItem
   Friend WithEvents tsmiAPDF As ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
   Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
   Friend WithEvents sfdExportar As SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
   Friend WithEvents cmbObservaciones As Controles.ComboBox
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents chkMesCompletoFEN As Controles.CheckBox
   Friend WithEvents chbFechaReprogEntrega As Controles.CheckBox
   Friend WithEvents chkMesCompletoFRE As Controles.CheckBox
   Friend WithEvents dtpFechaRepEntregaHasta As Controles.DateTimePicker
   Friend WithEvents Label5 As Controles.Label
   Friend WithEvents dtpFechaRepEntregaDesde As Controles.DateTimePicker
   Friend WithEvents Label6 As Controles.Label
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Controles.Label
   Friend WithEvents bscProducto2 As Controles.Buscador2
   Friend WithEvents chbProducto As Controles.CheckBox
   Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
   Friend WithEvents grpVerificaciones As GroupBox
   Friend WithEvents Label7 As Controles.Label
   Friend WithEvents cmbItems As Controles.ComboBox
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents cmbPrecios As Controles.ComboBox
   Friend WithEvents Label8 As Controles.Label
   Friend WithEvents cmbCant As Controles.ComboBox
   Friend WithEvents cmbFechaE As Controles.ComboBox
   Friend WithEvents Label10 As Controles.Label
   Friend WithEvents SplitContainer1 As SplitContainer
   Friend WithEvents chbOcultarFiltros As Controles.CheckBox
   Friend WithEvents lblEstado As Controles.Label
   Friend WithEvents cmbEstados As Controles.ComboBox
   Public WithEvents tsbPreferencias As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
   Friend WithEvents chkMesCompletoFA As Controles.CheckBox
   Friend WithEvents dtpFechaAutorizacionHasta As Controles.DateTimePicker
   Friend WithEvents Label14 As Controles.Label
   Friend WithEvents dtpFechaAutorizacionDesde As Controles.DateTimePicker
   Friend WithEvents Label15 As Controles.Label
   Friend WithEvents chbFechaAutorizacion As Controles.CheckBox
   Friend WithEvents chbVerUltimaActivacion As Controles.CheckBox
End Class
