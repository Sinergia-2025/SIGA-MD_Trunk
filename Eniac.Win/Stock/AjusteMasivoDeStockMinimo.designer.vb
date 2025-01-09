<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AjusteMasivoDeStockMinimo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjusteMasivoDeStockMinimo))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCorto")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Simbolo")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NuevoStock")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsCompuesto")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ubicacion")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NuevaUbicacion")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockMinimo")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NuevoStockMinimo")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PuntoDePedido")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NuevoPuntoDePedido")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockMaximo")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NuevoStockMaximo")
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
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbObtenerStock = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.clbSucursales = New Eniac.Controles.CheckedListBox()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.lblSucursales = New Eniac.Controles.Label()
        Me.cboCompuestos = New Eniac.Controles.ComboBox()
        Me.lblCompuestos = New Eniac.Controles.Label()
        Me.lnkFiltroMultiplesRubros = New System.Windows.Forms.LinkLabel()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.lnkFiltroMultiplesMarcas = New System.Windows.Forms.LinkLabel()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.chbStockMinimoMaximo = New Eniac.Controles.CheckBox()
        Me.chbAjustaUbicacion = New Eniac.Controles.CheckBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.cmbConStock = New Eniac.Controles.ComboBox()
        Me.lblConStock = New Eniac.Controles.Label()
        Me.ugDetalle = New Eniac.Win.UltraGridEditable()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.btnStockMaximo = New Eniac.Controles.Button()
        Me.txtStockMaximo = New Eniac.Controles.TextBox()
        Me.lblStockMaximo = New Eniac.Controles.Label()
        Me.btnPuntoDePedido = New Eniac.Controles.Button()
        Me.txtPuntoDePedido = New Eniac.Controles.TextBox()
        Me.lblPuntoDePedido = New Eniac.Controles.Label()
        Me.btnStockMinimo = New Eniac.Controles.Button()
        Me.txtStockMinimo = New Eniac.Controles.TextBox()
        Me.lblStockMinimo = New Eniac.Controles.Label()
        Me.pnlActualizarStockMinimo = New System.Windows.Forms.Panel()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActualizarStockMinimo.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
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
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbGrabar, Me.toolStripSeparator3, Me.tsbObtenerStock, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator6, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 4
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
        'tsbGrabar
        '
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        Me.toolStripSeparator3.Visible = False
        '
        'tsbObtenerStock
        '
        Me.tsbObtenerStock.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsbObtenerStock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbObtenerStock.Name = "tsbObtenerStock"
        Me.tsbObtenerStock.Size = New System.Drawing.Size(157, 26)
        Me.tsbObtenerStock.Text = "Importar Stock de &Excel"
        Me.tsbObtenerStock.Visible = False
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'clbSucursales
        '
        Me.clbSucursales.CheckOnClick = True
        Me.clbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.clbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.clbSucursales.FormattingEnabled = True
        Me.clbSucursales.IsPK = False
        Me.clbSucursales.IsRequired = False
        Me.clbSucursales.Key = Nothing
        Me.clbSucursales.LabelAsoc = Nothing
        Me.clbSucursales.Location = New System.Drawing.Point(10, 34)
        Me.clbSucursales.Name = "clbSucursales"
        Me.clbSucursales.Size = New System.Drawing.Size(131, 49)
        Me.clbSucursales.TabIndex = 1
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
        Me.chbProducto.Location = New System.Drawing.Point(261, 49)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 8
        Me.chbProducto.Text = "&Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'lblSucursales
        '
        Me.lblSucursales.AutoSize = True
        Me.lblSucursales.LabelAsoc = Nothing
        Me.lblSucursales.Location = New System.Drawing.Point(7, 20)
        Me.lblSucursales.Name = "lblSucursales"
        Me.lblSucursales.Size = New System.Drawing.Size(59, 13)
        Me.lblSucursales.TabIndex = 0
        Me.lblSucursales.Text = "Sucursales"
        '
        'cboCompuestos
        '
        Me.cboCompuestos.BindearPropiedadControl = Nothing
        Me.cboCompuestos.BindearPropiedadEntidad = Nothing
        Me.cboCompuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompuestos.ForeColorFocus = System.Drawing.Color.Red
        Me.cboCompuestos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboCompuestos.FormattingEnabled = True
        Me.cboCompuestos.IsPK = False
        Me.cboCompuestos.IsRequired = False
        Me.cboCompuestos.Key = Nothing
        Me.cboCompuestos.LabelAsoc = Me.lblCompuestos
        Me.cboCompuestos.Location = New System.Drawing.Point(817, 20)
        Me.cboCompuestos.Name = "cboCompuestos"
        Me.cboCompuestos.Size = New System.Drawing.Size(65, 21)
        Me.cboCompuestos.TabIndex = 12
        '
        'lblCompuestos
        '
        Me.lblCompuestos.AutoSize = True
        Me.lblCompuestos.LabelAsoc = Nothing
        Me.lblCompuestos.Location = New System.Drawing.Point(746, 24)
        Me.lblCompuestos.Name = "lblCompuestos"
        Me.lblCompuestos.Size = New System.Drawing.Size(65, 13)
        Me.lblCompuestos.TabIndex = 11
        Me.lblCompuestos.Text = "Compuestos"
        '
        'lnkFiltroMultiplesRubros
        '
        Me.lnkFiltroMultiplesRubros.AutoSize = True
        Me.lnkFiltroMultiplesRubros.Location = New System.Drawing.Point(147, 77)
        Me.lnkFiltroMultiplesRubros.Name = "lnkFiltroMultiplesRubros"
        Me.lnkFiltroMultiplesRubros.Size = New System.Drawing.Size(90, 13)
        Me.lnkFiltroMultiplesRubros.TabIndex = 3
        Me.lnkFiltroMultiplesRubros.TabStop = True
        Me.lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(879, 66)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(89, 40)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lnkFiltroMultiplesMarcas
        '
        Me.lnkFiltroMultiplesMarcas.AutoSize = True
        Me.lnkFiltroMultiplesMarcas.Location = New System.Drawing.Point(147, 50)
        Me.lnkFiltroMultiplesMarcas.Name = "lnkFiltroMultiplesMarcas"
        Me.lnkFiltroMultiplesMarcas.Size = New System.Drawing.Size(91, 13)
        Me.lnkFiltroMultiplesMarcas.TabIndex = 2
        Me.lnkFiltroMultiplesMarcas.TabStop = True
        Me.lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
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
        Me.cmbSubRubro.Location = New System.Drawing.Point(336, 20)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(245, 21)
        Me.cmbSubRubro.TabIndex = 5
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
        Me.bscProveedor.Location = New System.Drawing.Point(443, 73)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(309, 27)
        Me.bscProveedor.TabIndex = 15
        Me.bscProveedor.Titulo = Nothing
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
        Me.chbSubRubro.Location = New System.Drawing.Point(261, 22)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 4
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
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
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(336, 73)
        Me.bscCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(99, 23)
        Me.bscCodigoProveedor.TabIndex = 14
        Me.bscCodigoProveedor.Titulo = Nothing
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
        Me.chbProveedor.Location = New System.Drawing.Point(261, 76)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 13
        Me.chbProveedor.Text = "Pro&veedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.chbStockMinimoMaximo)
        Me.grbConsultar.Controls.Add(Me.chbAjustaUbicacion)
        Me.grbConsultar.Controls.Add(Me.bscProducto2)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProducto2)
        Me.grbConsultar.Controls.Add(Me.chbProveedor)
        Me.grbConsultar.Controls.Add(Me.clbSucursales)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.chbProducto)
        Me.grbConsultar.Controls.Add(Me.chbSubRubro)
        Me.grbConsultar.Controls.Add(Me.bscProveedor)
        Me.grbConsultar.Controls.Add(Me.lblSucursales)
        Me.grbConsultar.Controls.Add(Me.cmbSubRubro)
        Me.grbConsultar.Controls.Add(Me.cmbConStock)
        Me.grbConsultar.Controls.Add(Me.cboCompuestos)
        Me.grbConsultar.Controls.Add(Me.lnkFiltroMultiplesMarcas)
        Me.grbConsultar.Controls.Add(Me.btnBuscar)
        Me.grbConsultar.Controls.Add(Me.lblConStock)
        Me.grbConsultar.Controls.Add(Me.lnkFiltroMultiplesRubros)
        Me.grbConsultar.Controls.Add(Me.lblCompuestos)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbConsultar.Location = New System.Drawing.Point(0, 29)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(984, 116)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'chbStockMinimoMaximo
        '
        Me.chbStockMinimoMaximo.AutoSize = True
        Me.chbStockMinimoMaximo.BindearPropiedadControl = Nothing
        Me.chbStockMinimoMaximo.BindearPropiedadEntidad = Nothing
        Me.chbStockMinimoMaximo.Checked = True
        Me.chbStockMinimoMaximo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbStockMinimoMaximo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbStockMinimoMaximo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbStockMinimoMaximo.IsPK = False
        Me.chbStockMinimoMaximo.IsRequired = False
        Me.chbStockMinimoMaximo.Key = Nothing
        Me.chbStockMinimoMaximo.LabelAsoc = Nothing
        Me.chbStockMinimoMaximo.Location = New System.Drawing.Point(373, 103)
        Me.chbStockMinimoMaximo.Name = "chbStockMinimoMaximo"
        Me.chbStockMinimoMaximo.Size = New System.Drawing.Size(287, 17)
        Me.chbStockMinimoMaximo.TabIndex = 18
        Me.chbStockMinimoMaximo.Text = "Ajusta Stock Mínimo, Punto de Pedido y Stock Máximo"
        Me.chbStockMinimoMaximo.UseVisualStyleBackColor = True
        Me.chbStockMinimoMaximo.Visible = False
        '
        'chbAjustaUbicacion
        '
        Me.chbAjustaUbicacion.AutoSize = True
        Me.chbAjustaUbicacion.BindearPropiedadControl = Nothing
        Me.chbAjustaUbicacion.BindearPropiedadEntidad = Nothing
        Me.chbAjustaUbicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAjustaUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAjustaUbicacion.IsPK = False
        Me.chbAjustaUbicacion.IsRequired = False
        Me.chbAjustaUbicacion.Key = Nothing
        Me.chbAjustaUbicacion.LabelAsoc = Nothing
        Me.chbAjustaUbicacion.Location = New System.Drawing.Point(261, 103)
        Me.chbAjustaUbicacion.Name = "chbAjustaUbicacion"
        Me.chbAjustaUbicacion.Size = New System.Drawing.Size(106, 17)
        Me.chbAjustaUbicacion.TabIndex = 16
        Me.chbAjustaUbicacion.Text = "Ajusta Ubicacion"
        Me.chbAjustaUbicacion.UseVisualStyleBackColor = True
        Me.chbAjustaUbicacion.Visible = False
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
        Me.bscProducto2.Location = New System.Drawing.Point(443, 47)
        Me.bscProducto2.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(309, 20)
        Me.bscProducto2.TabIndex = 10
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
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(336, 47)
        Me.bscCodigoProducto2.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(99, 20)
        Me.bscCodigoProducto2.TabIndex = 9
        '
        'cmbConStock
        '
        Me.cmbConStock.BindearPropiedadControl = Nothing
        Me.cmbConStock.BindearPropiedadEntidad = Nothing
        Me.cmbConStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConStock.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbConStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbConStock.FormattingEnabled = True
        Me.cmbConStock.IsPK = False
        Me.cmbConStock.IsRequired = False
        Me.cmbConStock.Key = Nothing
        Me.cmbConStock.LabelAsoc = Me.lblConStock
        Me.cmbConStock.Location = New System.Drawing.Point(653, 20)
        Me.cmbConStock.Name = "cmbConStock"
        Me.cmbConStock.Size = New System.Drawing.Size(80, 21)
        Me.cmbConStock.TabIndex = 7
        '
        'lblConStock
        '
        Me.lblConStock.AutoSize = True
        Me.lblConStock.LabelAsoc = Nothing
        Me.lblConStock.Location = New System.Drawing.Point(590, 24)
        Me.lblConStock.Name = "lblConStock"
        Me.lblConStock.Size = New System.Drawing.Size(57, 13)
        Me.lblConStock.TabIndex = 6
        Me.lblConStock.Text = "Con Stock"
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 60
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "Sucursal"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 80
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance3
        UltraGridColumn3.Header.Caption = "Código"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 90
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "Producto"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 235
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 80
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "Marca"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 150
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Rubro"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 150
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 40
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn9.CellAppearance = Appearance4
        UltraGridColumn9.Header.Caption = "M"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 40
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance5
        UltraGridColumn10.Header.Caption = "Precio"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 70
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance6
        UltraGridColumn11.Format = "N2"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.MaskInput = ""
        UltraGridColumn11.Width = 60
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance7
        UltraGridColumn12.Format = "N2"
        UltraGridColumn12.Header.Caption = "Nuevo Stock"
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.MaskInput = "{double:9.2}"
        UltraGridColumn12.Width = 60
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance8
        UltraGridColumn13.Header.Caption = "Form."
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 40
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.Caption = "Ubicación"
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 100
        UltraGridColumn15.Header.Caption = "Nueva Ubicación"
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 100
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance9
        UltraGridColumn16.Format = "N2"
        UltraGridColumn16.Header.Caption = "Stock Mínimo"
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Width = 60
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance10
        UltraGridColumn17.Format = "N2"
        UltraGridColumn17.Header.Caption = "Nuevo Stock Mínimo"
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.MaskInput = "{double:9.2}"
        UltraGridColumn17.Width = 60
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance11
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "Punto De Pedido"
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Width = 60
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance12
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "Nuevo Punto De Pedido"
        UltraGridColumn19.Header.VisiblePosition = 18
        UltraGridColumn19.MaskInput = "{double:9.2}"
        UltraGridColumn19.Width = 60
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance13
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.Caption = "Stock Máximo"
        UltraGridColumn20.Header.VisiblePosition = 19
        UltraGridColumn20.Width = 49
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance14
        UltraGridColumn21.Format = "N2"
        UltraGridColumn21.Header.Caption = "Nuevo Stock Máximo"
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridColumn21.MaskInput = "{double:9.2}"
        UltraGridColumn21.Width = 60
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
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
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.EnterMueveACeldaDeAbajo = True
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 171)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 368)
        Me.ugDetalle.TabIndex = 2
        Me.ugDetalle.ToolStripLabelRegistros = Nothing
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
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
        'btnStockMaximo
        '
        Me.btnStockMaximo.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnStockMaximo.Location = New System.Drawing.Point(961, 1)
        Me.btnStockMaximo.Name = "btnStockMaximo"
        Me.btnStockMaximo.Size = New System.Drawing.Size(22, 22)
        Me.btnStockMaximo.TabIndex = 8
        Me.btnStockMaximo.TabStop = False
        Me.btnStockMaximo.Tag = "DescuentoRecargoPorcNuevo3"
        Me.btnStockMaximo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStockMaximo.UseVisualStyleBackColor = True
        '
        'txtStockMaximo
        '
        Me.txtStockMaximo.BindearPropiedadControl = Nothing
        Me.txtStockMaximo.BindearPropiedadEntidad = Nothing
        Me.txtStockMaximo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStockMaximo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStockMaximo.Formato = "N2"
        Me.txtStockMaximo.IsDecimal = True
        Me.txtStockMaximo.IsNumber = True
        Me.txtStockMaximo.IsPK = False
        Me.txtStockMaximo.IsRequired = False
        Me.txtStockMaximo.Key = ""
        Me.txtStockMaximo.LabelAsoc = Me.lblStockMaximo
        Me.txtStockMaximo.Location = New System.Drawing.Point(911, 2)
        Me.txtStockMaximo.Name = "txtStockMaximo"
        Me.txtStockMaximo.Size = New System.Drawing.Size(50, 20)
        Me.txtStockMaximo.TabIndex = 7
        Me.txtStockMaximo.Text = "0,00"
        Me.txtStockMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStockMaximo
        '
        Me.lblStockMaximo.AutoSize = True
        Me.lblStockMaximo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStockMaximo.LabelAsoc = Nothing
        Me.lblStockMaximo.Location = New System.Drawing.Point(832, 6)
        Me.lblStockMaximo.Name = "lblStockMaximo"
        Me.lblStockMaximo.Size = New System.Drawing.Size(74, 13)
        Me.lblStockMaximo.TabIndex = 6
        Me.lblStockMaximo.Text = "Stock Máximo"
        '
        'btnPuntoDePedido
        '
        Me.btnPuntoDePedido.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnPuntoDePedido.Location = New System.Drawing.Point(810, 1)
        Me.btnPuntoDePedido.Name = "btnPuntoDePedido"
        Me.btnPuntoDePedido.Size = New System.Drawing.Size(22, 22)
        Me.btnPuntoDePedido.TabIndex = 5
        Me.btnPuntoDePedido.TabStop = False
        Me.btnPuntoDePedido.Tag = "DescuentoRecargoPorcNuevo2"
        Me.btnPuntoDePedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPuntoDePedido.UseVisualStyleBackColor = True
        '
        'txtPuntoDePedido
        '
        Me.txtPuntoDePedido.BindearPropiedadControl = Nothing
        Me.txtPuntoDePedido.BindearPropiedadEntidad = Nothing
        Me.txtPuntoDePedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPuntoDePedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPuntoDePedido.Formato = "N2"
        Me.txtPuntoDePedido.IsDecimal = True
        Me.txtPuntoDePedido.IsNumber = True
        Me.txtPuntoDePedido.IsPK = False
        Me.txtPuntoDePedido.IsRequired = False
        Me.txtPuntoDePedido.Key = ""
        Me.txtPuntoDePedido.LabelAsoc = Me.lblPuntoDePedido
        Me.txtPuntoDePedido.Location = New System.Drawing.Point(760, 2)
        Me.txtPuntoDePedido.Name = "txtPuntoDePedido"
        Me.txtPuntoDePedido.Size = New System.Drawing.Size(50, 20)
        Me.txtPuntoDePedido.TabIndex = 4
        Me.txtPuntoDePedido.Text = "0,00"
        Me.txtPuntoDePedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPuntoDePedido
        '
        Me.lblPuntoDePedido.AutoSize = True
        Me.lblPuntoDePedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPuntoDePedido.LabelAsoc = Nothing
        Me.lblPuntoDePedido.Location = New System.Drawing.Point(668, 6)
        Me.lblPuntoDePedido.Name = "lblPuntoDePedido"
        Me.lblPuntoDePedido.Size = New System.Drawing.Size(86, 13)
        Me.lblPuntoDePedido.TabIndex = 3
        Me.lblPuntoDePedido.Text = "Punto de Pedido"
        '
        'btnStockMinimo
        '
        Me.btnStockMinimo.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnStockMinimo.Location = New System.Drawing.Point(646, 1)
        Me.btnStockMinimo.Name = "btnStockMinimo"
        Me.btnStockMinimo.Size = New System.Drawing.Size(22, 22)
        Me.btnStockMinimo.TabIndex = 2
        Me.btnStockMinimo.TabStop = False
        Me.btnStockMinimo.Tag = "DescuentoRecargoPorcNuevo1"
        Me.btnStockMinimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStockMinimo.UseVisualStyleBackColor = True
        '
        'txtStockMinimo
        '
        Me.txtStockMinimo.BindearPropiedadControl = Nothing
        Me.txtStockMinimo.BindearPropiedadEntidad = Nothing
        Me.txtStockMinimo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStockMinimo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStockMinimo.Formato = "N2"
        Me.txtStockMinimo.IsDecimal = True
        Me.txtStockMinimo.IsNumber = True
        Me.txtStockMinimo.IsPK = False
        Me.txtStockMinimo.IsRequired = False
        Me.txtStockMinimo.Key = ""
        Me.txtStockMinimo.LabelAsoc = Me.lblStockMinimo
        Me.txtStockMinimo.Location = New System.Drawing.Point(596, 2)
        Me.txtStockMinimo.Name = "txtStockMinimo"
        Me.txtStockMinimo.Size = New System.Drawing.Size(50, 20)
        Me.txtStockMinimo.TabIndex = 1
        Me.txtStockMinimo.Text = "0,00"
        Me.txtStockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStockMinimo
        '
        Me.lblStockMinimo.AutoSize = True
        Me.lblStockMinimo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStockMinimo.LabelAsoc = Nothing
        Me.lblStockMinimo.Location = New System.Drawing.Point(517, 6)
        Me.lblStockMinimo.Name = "lblStockMinimo"
        Me.lblStockMinimo.Size = New System.Drawing.Size(73, 13)
        Me.lblStockMinimo.TabIndex = 0
        Me.lblStockMinimo.Text = "Stock Mínimo"
        '
        'pnlActualizarStockMinimo
        '
        Me.pnlActualizarStockMinimo.AutoSize = True
        Me.pnlActualizarStockMinimo.Controls.Add(Me.txtStockMinimo)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.btnStockMaximo)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.lblStockMinimo)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.txtStockMaximo)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.lblPuntoDePedido)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.btnPuntoDePedido)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.btnStockMinimo)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.txtPuntoDePedido)
        Me.pnlActualizarStockMinimo.Controls.Add(Me.lblStockMaximo)
        Me.pnlActualizarStockMinimo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActualizarStockMinimo.Location = New System.Drawing.Point(0, 145)
        Me.pnlActualizarStockMinimo.Name = "pnlActualizarStockMinimo"
        Me.pnlActualizarStockMinimo.Size = New System.Drawing.Size(984, 26)
        Me.pnlActualizarStockMinimo.TabIndex = 1
        '
        'AjusteMasivoDeStockMinimo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlActualizarStockMinimo)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "AjusteMasivoDeStockMinimo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste Masivo de Stock Minimo, Maximo y Punto de Pedido"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActualizarStockMinimo.ResumeLayout(False)
        Me.pnlActualizarStockMinimo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents lblSucursales As Eniac.Controles.Label
   Friend WithEvents cboCompuestos As Eniac.Controles.ComboBox
   Friend WithEvents lblCompuestos As Eniac.Controles.Label
   Friend WithEvents lnkFiltroMultiplesRubros As System.Windows.Forms.LinkLabel
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents lnkFiltroMultiplesMarcas As System.Windows.Forms.LinkLabel
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbAjustaUbicacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbConStock As Eniac.Controles.ComboBox
   Friend WithEvents lblConStock As Eniac.Controles.Label
   Friend WithEvents ugDetalle As UltraGridEditable
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbObtenerStock As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbStockMinimoMaximo As Controles.CheckBox
   Friend WithEvents btnStockMaximo As Controles.Button
   Friend WithEvents txtStockMaximo As Controles.TextBox
   Friend WithEvents lblStockMaximo As Controles.Label
   Friend WithEvents btnPuntoDePedido As Controles.Button
   Friend WithEvents txtPuntoDePedido As Controles.TextBox
   Friend WithEvents lblPuntoDePedido As Controles.Label
   Friend WithEvents btnStockMinimo As Controles.Button
   Friend WithEvents txtStockMinimo As Controles.TextBox
   Friend WithEvents lblStockMinimo As Controles.Label
   Friend WithEvents pnlActualizarStockMinimo As Panel
End Class
