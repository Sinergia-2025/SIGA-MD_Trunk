<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarPedidoProvDesdePedCliente
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarPedidoProvDesdePedCliente))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedido")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PedidoOriginal")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ProveedoresAlternativos")
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedor")
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estimativo")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RespetaPreciosOrdenCompra")
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGenerarPedido = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Eniac.Win.UltraGridEditable()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.cmbEstados = New Eniac.Controles.ComboBox()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.llbProveedor = New Eniac.Controles.LinkLabel()
      Me.chbOrdenCompra = New Eniac.Controles.CheckBox()
      Me.txtOrdenCompra = New Eniac.Controles.TextBox()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.bscProveedor = New Eniac.Controles.Buscador2()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.chbSubRubro = New Eniac.Controles.CheckBox()
      Me.cmbSubRubro = New Eniac.Controles.ComboBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.chbRubro = New Eniac.Controles.CheckBox()
      Me.cmbRubro = New Eniac.Controles.ComboBox()
      Me.chbMarca = New Eniac.Controles.CheckBox()
      Me.cmbMarca = New Eniac.Controles.ComboBox()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbGenerarPedido, Me.ToolStripSeparator4, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 2
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
      'tsbGenerarPedido
      '
      Me.tsbGenerarPedido.Image = Global.Eniac.Win.My.Resources.Resources.exchange1
      Me.tsbGenerarPedido.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGenerarPedido.Name = "tsbGenerarPedido"
      Me.tsbGenerarPedido.Size = New System.Drawing.Size(137, 26)
      Me.tsbGenerarPedido.Text = "Generar Pedido (F4)"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'ugDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn45.CellAppearance = Appearance2
      UltraGridColumn45.Header.VisiblePosition = 0
      UltraGridColumn45.Hidden = True
      UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn46.Header.Caption = "Sucursal"
      UltraGridColumn46.Header.VisiblePosition = 1
      UltraGridColumn46.Hidden = True
      UltraGridColumn46.Width = 103
      UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn47.CellAppearance = Appearance3
      UltraGridColumn47.Header.Caption = "Codigo"
      UltraGridColumn47.Header.VisiblePosition = 3
      UltraGridColumn47.Width = 108
      UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn48.Header.Caption = "Producto"
      UltraGridColumn48.Header.VisiblePosition = 5
      UltraGridColumn48.Width = 304
      UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn49.CellAppearance = Appearance4
      UltraGridColumn49.Header.VisiblePosition = 6
      UltraGridColumn49.Hidden = True
      UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn50.Header.Caption = "Marca"
      UltraGridColumn50.Header.VisiblePosition = 12
      UltraGridColumn50.Width = 125
      UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn51.CellAppearance = Appearance5
      UltraGridColumn51.Header.VisiblePosition = 7
      UltraGridColumn51.Hidden = True
      UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn52.Header.Caption = "Rubro"
      UltraGridColumn52.Header.VisiblePosition = 13
      UltraGridColumn52.Width = 113
      UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn53.CellAppearance = Appearance6
      UltraGridColumn53.Format = "N2"
      Appearance7.TextHAlignAsString = "Center"
      UltraGridColumn53.Header.Appearance = Appearance7
      UltraGridColumn53.Header.VisiblePosition = 8
      UltraGridColumn53.Width = 74
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn57.CellAppearance = Appearance8
      UltraGridColumn57.Format = "N2"
      Appearance9.TextHAlignAsString = "Center"
      UltraGridColumn57.Header.Appearance = Appearance9
      UltraGridColumn57.Header.VisiblePosition = 9
      UltraGridColumn57.MaskInput = "{double:9.2}"
      UltraGridColumn57.Width = 93
      UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn58.Header.VisiblePosition = 14
      UltraGridColumn58.Hidden = True
      UltraGridColumn58.Width = 89
      UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn59.Header.Caption = "Observaciones"
      UltraGridColumn59.Header.VisiblePosition = 16
      UltraGridColumn59.Width = 300
      UltraGridColumn60.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn60.Header.VisiblePosition = 17
      UltraGridColumn60.Hidden = True
      UltraGridColumn61.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn61.Header.Caption = "Prov. Habit."
      UltraGridColumn61.Header.VisiblePosition = 18
      UltraGridColumn61.Hidden = True
      UltraGridColumn62.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn62.Header.Caption = "Nombre Proveedor Habitual"
      UltraGridColumn62.Header.VisiblePosition = 19
      UltraGridColumn62.Width = 150
      UltraGridColumn63.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn63.Header.Caption = "Proveedores Alternativos"
      UltraGridColumn63.Header.VisiblePosition = 20
      UltraGridColumn63.Width = 300
      UltraGridColumn64.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn64.Header.Caption = "Codigo Prov."
      UltraGridColumn64.Header.VisiblePosition = 4
      UltraGridColumn64.Width = 76
      UltraGridColumn65.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn65.CellAppearance = Appearance10
      UltraGridColumn65.Format = "N2"
      UltraGridColumn65.Header.VisiblePosition = 10
      UltraGridColumn66.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn66.CellAppearance = Appearance11
      UltraGridColumn66.Format = "N2"
      UltraGridColumn66.Header.VisiblePosition = 11
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance12
      Appearance13.TextHAlignAsString = "Center"
      UltraGridColumn1.Header.Appearance = Appearance13
      UltraGridColumn1.Header.Caption = "OC"
      UltraGridColumn1.Header.TextOrientation = New Infragistics.Win.TextOrientationInfo(0, Infragistics.Win.TextFlowDirection.Horizontal)
      UltraGridColumn1.Header.VisiblePosition = 2
      UltraGridColumn1.Width = 62
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance14
      UltraGridColumn2.Format = "N2"
      UltraGridColumn2.Header.VisiblePosition = 15
      UltraGridColumn3.Header.VisiblePosition = 21
      UltraGridColumn3.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
      UltraGridBand1.SummaryFooterCaption = "Totales:"
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance15.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance15
      Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance17.BackColor2 = System.Drawing.SystemColors.Control
      Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance18.BackColor = System.Drawing.SystemColors.Window
      Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance18
      Appearance19.BackColor = System.Drawing.SystemColors.Highlight
      Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance19
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance20.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance20
      Appearance21.BorderColor = System.Drawing.Color.Silver
      Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance21
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance22.BackColor = System.Drawing.SystemColors.Control
      Appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance22.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance22
      Appearance23.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance23
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance24.BackColor = System.Drawing.SystemColors.Window
      Appearance24.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance24
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(0, 0)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(984, 391)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
      Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
      Me.ugDetalle.ToolStripMenuExpandir = Nothing
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Lista de Precios Múltiples"
      Me.UltraGridPrintDocument1.FitWidthToPages = 1
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance26.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance26
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
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.lblEstado)
      Me.grbFiltros.Controls.Add(Me.cmbEstados)
      Me.grbFiltros.Controls.Add(Me.chbFecha)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.llbProveedor)
      Me.grbFiltros.Controls.Add(Me.chbOrdenCompra)
      Me.grbFiltros.Controls.Add(Me.txtOrdenCompra)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.bscProveedor)
      Me.grbFiltros.Controls.Add(Me.chbProveedor)
      Me.grbFiltros.Controls.Add(Me.bscProducto2)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
      Me.grbFiltros.Controls.Add(Me.chbSubRubro)
      Me.grbFiltros.Controls.Add(Me.cmbSubRubro)
      Me.grbFiltros.Controls.Add(Me.chkExpandAll)
      Me.grbFiltros.Controls.Add(Me.chbRubro)
      Me.grbFiltros.Controls.Add(Me.cmbRubro)
      Me.grbFiltros.Controls.Add(Me.chbMarca)
      Me.grbFiltros.Controls.Add(Me.cmbMarca)
      Me.grbFiltros.Controls.Add(Me.chbProducto)
      Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
      Me.grbFiltros.Location = New System.Drawing.Point(0, 29)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(984, 119)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(519, 51)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 60
      Me.lblEstado.Text = "Estado"
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
      Me.cmbEstados.Location = New System.Drawing.Point(565, 47)
      Me.cmbEstados.Name = "cmbEstados"
      Me.cmbEstados.Size = New System.Drawing.Size(140, 21)
      Me.cmbEstados.TabIndex = 61
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
      Me.chbFecha.Location = New System.Drawing.Point(14, 49)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(56, 17)
      Me.chbFecha.TabIndex = 54
      Me.chbFecha.Text = "Fecha"
      Me.chbFecha.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(93, 49)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
      Me.chkMesCompleto.TabIndex = 55
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
      Me.dtpHasta.Location = New System.Drawing.Point(374, 47)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
      Me.dtpHasta.TabIndex = 59
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(333, 51)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 58
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
      Me.dtpDesde.Location = New System.Drawing.Point(196, 47)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
      Me.dtpDesde.TabIndex = 57
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(152, 51)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 56
      Me.lblDesde.Text = "Desde"
      '
      'llbProveedor
      '
      Me.llbProveedor.AutoSize = True
      Me.llbProveedor.LabelAsoc = Nothing
      Me.llbProveedor.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
      Me.llbProveedor.Location = New System.Drawing.Point(400, 6)
      Me.llbProveedor.Name = "llbProveedor"
      Me.llbProveedor.Size = New System.Drawing.Size(55, 13)
      Me.llbProveedor.TabIndex = 53
      Me.llbProveedor.TabStop = True
      Me.llbProveedor.Text = "más info..."
      Me.llbProveedor.Visible = False
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
      Me.chbOrdenCompra.Location = New System.Drawing.Point(14, 23)
      Me.chbOrdenCompra.Name = "chbOrdenCompra"
      Me.chbOrdenCompra.Size = New System.Drawing.Size(109, 17)
      Me.chbOrdenCompra.TabIndex = 51
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
      Me.txtOrdenCompra.Location = New System.Drawing.Point(127, 21)
      Me.txtOrdenCompra.MaxLength = 6
      Me.txtOrdenCompra.Name = "txtOrdenCompra"
      Me.txtOrdenCompra.Size = New System.Drawing.Size(90, 20)
      Me.txtOrdenCompra.TabIndex = 0
      Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(303, 20)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = False
      Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 1
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
      Me.bscProveedor.Location = New System.Drawing.Point(400, 20)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = False
      Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(371, 23)
      Me.bscProveedor.TabIndex = 2
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
      Me.chbProveedor.Location = New System.Drawing.Point(225, 23)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 4
      Me.chbProveedor.Text = "Proveedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
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
      Me.bscProducto2.Location = New System.Drawing.Point(259, 71)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = False
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(347, 20)
      Me.bscProducto2.TabIndex = 4
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
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(93, 71)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = False
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(160, 20)
      Me.bscCodigoProducto2.TabIndex = 3
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
      Me.chbSubRubro.Location = New System.Drawing.Point(537, 97)
      Me.chbSubRubro.Name = "chbSubRubro"
      Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
      Me.chbSubRubro.TabIndex = 15
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
      Me.cmbSubRubro.Location = New System.Drawing.Point(612, 95)
      Me.cmbSubRubro.Name = "cmbSubRubro"
      Me.cmbSubRubro.Size = New System.Drawing.Size(180, 21)
      Me.cmbSubRubro.TabIndex = 7
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Location = New System.Drawing.Point(870, 96)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(96, 20)
      Me.chkExpandAll.TabIndex = 18
      Me.chkExpandAll.Text = "Expandir todo"
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
      Me.chbRubro.Location = New System.Drawing.Point(290, 97)
      Me.chbRubro.Name = "chbRubro"
      Me.chbRubro.Size = New System.Drawing.Size(55, 17)
      Me.chbRubro.TabIndex = 13
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
      Me.cmbRubro.Location = New System.Drawing.Point(351, 95)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(180, 21)
      Me.cmbRubro.TabIndex = 6
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
      Me.chbMarca.Location = New System.Drawing.Point(14, 97)
      Me.chbMarca.Name = "chbMarca"
      Me.chbMarca.Size = New System.Drawing.Size(56, 17)
      Me.chbMarca.TabIndex = 11
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
      Me.cmbMarca.Location = New System.Drawing.Point(92, 95)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(180, 21)
      Me.cmbMarca.TabIndex = 5
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
      Me.chbProducto.Location = New System.Drawing.Point(14, 73)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 8
      Me.chbProducto.Text = "Producto"
      Me.chbProducto.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(870, 3)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
      Me.btnConsultar.TabIndex = 8
      Me.btnConsultar.Text = "&Consultar (F3)"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(905, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.btnConsultar)
      Me.Panel1.Controls.Add(Me.ugDetalle)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel1.Location = New System.Drawing.Point(0, 148)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(984, 391)
      Me.Panel1.TabIndex = 4
      '
      'GenerarPedidoProvDesdePedCliente
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "GenerarPedidoProvDesdePedCliente"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Generar Pedido de Proveedor desde Pedidos de Clientes"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As UltraGridEditable
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents tsbGenerarPedido As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbOrdenCompra As Eniac.Controles.CheckBox
   Friend WithEvents txtOrdenCompra As Eniac.Controles.TextBox
   Friend WithEvents llbProveedor As Eniac.Controles.LinkLabel
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents cmbEstados As Eniac.Controles.ComboBox
    Friend WithEvents Panel1 As Panel
End Class
