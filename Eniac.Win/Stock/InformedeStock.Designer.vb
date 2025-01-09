<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InformedeStock
    Inherits BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformedeStock))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmpresa")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpresa")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeposito")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoUbicacion")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdModelo")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubSubRubro")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreModelo")
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubSubRubro")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockInicial")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaConImpuestos")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoConImpuestos")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaSinImpuestos")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoSinImpuestos")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedor")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Embalaje")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedorHabitual")
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrupoAtributo01")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoAtributo01")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrupoAtributo02")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoAtributo02")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Atributos")
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
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdaAtributo")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAtributo")
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbStockUnificadoPor = New Eniac.Controles.ComboBox()
        Me.lblOrdenadoPor = New Eniac.Controles.Label()
        Me.lblStockUnificadoPor = New Eniac.Controles.Label()
        Me.cmbOrdenadoPor = New Eniac.Controles.ComboBox()
        Me.cmbTipoInforme = New Eniac.Controles.ComboBox()
        Me.lblTipoInforme = New Eniac.Controles.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.cmbTipoDeposito = New Eniac.Controles.ComboBox()
        Me.chbTipoDeposito = New Eniac.Controles.CheckBox()
        Me.cmbDepositos = New Eniac.Win.ComboBoxDepositos()
        Me.chbDeposito = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbMostrarPrecio = New Eniac.Controles.ComboBox()
        Me.lblMostrarPrecio = New Eniac.Controles.Label()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.bscProveedor = New Eniac.Controles.Buscador2()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.chbEmbalaje = New Eniac.Controles.CheckBox()
        Me.chbProveedorHabitual = New Eniac.Controles.CheckBox()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
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
        Me.btnConsultar = New Eniac.Win.ButtonConsultar()
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.tbcInformeStock = New System.Windows.Forms.TabControl()
        Me.tbpStock = New System.Windows.Forms.TabPage()
        Me.tbpAtributoProducto = New System.Windows.Forms.TabPage()
        Me.ugStockAtributo = New Eniac.Win.UltraGridSiga()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlModelos.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.pnlSubSubRubros.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tbcInformeStock.SuspendLayout()
        Me.tbpStock.SuspendLayout()
        Me.tbpAtributoProducto.SuspendLayout()
        CType(Me.ugStockAtributo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator3, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbImprimir2, Me.ToolStripSeparator5, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1084, 29)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'tsbImprimir2
        '
        Me.tsbImprimir2.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir2.Name = "tsbImprimir2"
        Me.tsbImprimir2.Size = New System.Drawing.Size(125, 26)
        Me.tsbImprimir2.Text = "Imp. &Prediseñado"
        Me.tsbImprimir2.ToolTipText = "Imprimir Reporte Prediseñado"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.TableLayoutPanel1)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbConsultar.Location = New System.Drawing.Point(0, 29)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1084, 183)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1078, 164)
        Me.TableLayoutPanel1.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.cmbStockUnificadoPor)
        Me.Panel2.Controls.Add(Me.lblStockUnificadoPor)
        Me.Panel2.Controls.Add(Me.cmbOrdenadoPor)
        Me.Panel2.Controls.Add(Me.lblOrdenadoPor)
        Me.Panel2.Controls.Add(Me.cmbTipoInforme)
        Me.Panel2.Controls.Add(Me.lblTipoInforme)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 137)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1072, 25)
        Me.Panel2.TabIndex = 33
        '
        'cmbStockUnificadoPor
        '
        Me.cmbStockUnificadoPor.BindearPropiedadControl = Nothing
        Me.cmbStockUnificadoPor.BindearPropiedadEntidad = Nothing
        Me.cmbStockUnificadoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStockUnificadoPor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbStockUnificadoPor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbStockUnificadoPor.FormattingEnabled = True
        Me.cmbStockUnificadoPor.IsPK = False
        Me.cmbStockUnificadoPor.IsRequired = False
        Me.cmbStockUnificadoPor.Key = Nothing
        Me.cmbStockUnificadoPor.LabelAsoc = Me.lblOrdenadoPor
        Me.cmbStockUnificadoPor.Location = New System.Drawing.Point(669, 1)
        Me.cmbStockUnificadoPor.Name = "cmbStockUnificadoPor"
        Me.cmbStockUnificadoPor.Size = New System.Drawing.Size(176, 21)
        Me.cmbStockUnificadoPor.TabIndex = 27
        '
        'lblOrdenadoPor
        '
        Me.lblOrdenadoPor.AutoSize = True
        Me.lblOrdenadoPor.LabelAsoc = Nothing
        Me.lblOrdenadoPor.Location = New System.Drawing.Point(301, 5)
        Me.lblOrdenadoPor.Name = "lblOrdenadoPor"
        Me.lblOrdenadoPor.Size = New System.Drawing.Size(72, 13)
        Me.lblOrdenadoPor.TabIndex = 25
        Me.lblOrdenadoPor.Text = "Ordenado por"
        '
        'lblStockUnificadoPor
        '
        Me.lblStockUnificadoPor.AutoSize = True
        Me.lblStockUnificadoPor.LabelAsoc = Nothing
        Me.lblStockUnificadoPor.Location = New System.Drawing.Point(570, 5)
        Me.lblStockUnificadoPor.Name = "lblStockUnificadoPor"
        Me.lblStockUnificadoPor.Size = New System.Drawing.Size(92, 13)
        Me.lblStockUnificadoPor.TabIndex = 2
        Me.lblStockUnificadoPor.Text = "Unificar Stock por"
        '
        'cmbOrdenadoPor
        '
        Me.cmbOrdenadoPor.BindearPropiedadControl = Nothing
        Me.cmbOrdenadoPor.BindearPropiedadEntidad = Nothing
        Me.cmbOrdenadoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrdenadoPor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrdenadoPor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrdenadoPor.FormattingEnabled = True
        Me.cmbOrdenadoPor.IsPK = False
        Me.cmbOrdenadoPor.IsRequired = False
        Me.cmbOrdenadoPor.Key = Nothing
        Me.cmbOrdenadoPor.LabelAsoc = Me.lblOrdenadoPor
        Me.cmbOrdenadoPor.Location = New System.Drawing.Point(381, 1)
        Me.cmbOrdenadoPor.Name = "cmbOrdenadoPor"
        Me.cmbOrdenadoPor.Size = New System.Drawing.Size(176, 21)
        Me.cmbOrdenadoPor.TabIndex = 26
        '
        'cmbTipoInforme
        '
        Me.cmbTipoInforme.BindearPropiedadControl = Nothing
        Me.cmbTipoInforme.BindearPropiedadEntidad = Nothing
        Me.cmbTipoInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoInforme.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoInforme.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoInforme.FormattingEnabled = True
        Me.cmbTipoInforme.IsPK = False
        Me.cmbTipoInforme.IsRequired = False
        Me.cmbTipoInforme.Key = Nothing
        Me.cmbTipoInforme.LabelAsoc = Me.lblTipoInforme
        Me.cmbTipoInforme.Location = New System.Drawing.Point(113, 1)
        Me.cmbTipoInforme.Name = "cmbTipoInforme"
        Me.cmbTipoInforme.Size = New System.Drawing.Size(176, 21)
        Me.cmbTipoInforme.TabIndex = 24
        '
        'lblTipoInforme
        '
        Me.lblTipoInforme.AutoSize = True
        Me.lblTipoInforme.LabelAsoc = Nothing
        Me.lblTipoInforme.Location = New System.Drawing.Point(38, 5)
        Me.lblTipoInforme.Name = "lblTipoInforme"
        Me.lblTipoInforme.Size = New System.Drawing.Size(69, 13)
        Me.lblTipoInforme.TabIndex = 23
        Me.lblTipoInforme.Text = "Tipo Informe:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.bscProducto2)
        Me.Panel1.Controls.Add(Me.bscCodigoProducto2)
        Me.Panel1.Controls.Add(Me.chbProducto)
        Me.Panel1.Controls.Add(Me.cmbTipoDeposito)
        Me.Panel1.Controls.Add(Me.chbTipoDeposito)
        Me.Panel1.Controls.Add(Me.cmbDepositos)
        Me.Panel1.Controls.Add(Me.chbDeposito)
        Me.Panel1.Controls.Add(Me.cmbSucursal)
        Me.Panel1.Controls.Add(Me.lblSucursal)
        Me.Panel1.Controls.Add(Me.cmbMostrarPrecio)
        Me.Panel1.Controls.Add(Me.chbConIVA)
        Me.Panel1.Controls.Add(Me.lblMostrarPrecio)
        Me.Panel1.Controls.Add(Me.bscProveedor)
        Me.Panel1.Controls.Add(Me.bscCodigoProveedor)
        Me.Panel1.Controls.Add(Me.chbEmbalaje)
        Me.Panel1.Controls.Add(Me.chbProveedorHabitual)
        Me.Panel1.Controls.Add(Me.chbProveedor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1072, 77)
        Me.Panel1.TabIndex = 31
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
        Me.bscProducto2.Location = New System.Drawing.Point(242, 52)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = False
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(289, 20)
        Me.bscProducto2.TabIndex = 29
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(113, 52)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = False
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(123, 20)
        Me.bscCodigoProducto2.TabIndex = 28
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
        Me.chbProducto.Location = New System.Drawing.Point(22, 54)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 27
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'cmbTipoDeposito
        '
        Me.cmbTipoDeposito.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoDeposito.BindearPropiedadEntidad = "TipoDeposito"
        Me.cmbTipoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeposito.Enabled = False
        Me.cmbTipoDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDeposito.FormattingEnabled = True
        Me.cmbTipoDeposito.IsPK = False
        Me.cmbTipoDeposito.IsRequired = False
        Me.cmbTipoDeposito.Key = Nothing
        Me.cmbTipoDeposito.LabelAsoc = Me.chbTipoDeposito
        Me.cmbTipoDeposito.Location = New System.Drawing.Point(628, -1)
        Me.cmbTipoDeposito.Name = "cmbTipoDeposito"
        Me.cmbTipoDeposito.Size = New System.Drawing.Size(148, 21)
        Me.cmbTipoDeposito.TabIndex = 6
        '
        'chbTipoDeposito
        '
        Me.chbTipoDeposito.AutoSize = True
        Me.chbTipoDeposito.BindearPropiedadControl = Nothing
        Me.chbTipoDeposito.BindearPropiedadEntidad = Nothing
        Me.chbTipoDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoDeposito.IsPK = False
        Me.chbTipoDeposito.IsRequired = False
        Me.chbTipoDeposito.Key = Nothing
        Me.chbTipoDeposito.LabelAsoc = Nothing
        Me.chbTipoDeposito.Location = New System.Drawing.Point(535, 1)
        Me.chbTipoDeposito.Name = "chbTipoDeposito"
        Me.chbTipoDeposito.Size = New System.Drawing.Size(92, 17)
        Me.chbTipoDeposito.TabIndex = 5
        Me.chbTipoDeposito.Text = "Tipo Depósito"
        '
        'cmbDepositos
        '
        Me.cmbDepositos.BindearPropiedadControl = Nothing
        Me.cmbDepositos.BindearPropiedadEntidad = Nothing
        Me.cmbDepositos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositos.FormattingEnabled = True
        Me.cmbDepositos.IsPK = False
        Me.cmbDepositos.IsRequired = False
        Me.cmbDepositos.Key = Nothing
        Me.cmbDepositos.LabelAsoc = Nothing
        Me.cmbDepositos.Location = New System.Drawing.Point(319, -1)
        Me.cmbDepositos.Name = "cmbDepositos"
        Me.cmbDepositos.Size = New System.Drawing.Size(135, 21)
        Me.cmbDepositos.TabIndex = 4
        '
        'chbDeposito
        '
        Me.chbDeposito.AutoSize = True
        Me.chbDeposito.LabelAsoc = Nothing
        Me.chbDeposito.Location = New System.Drawing.Point(264, 3)
        Me.chbDeposito.Name = "chbDeposito"
        Me.chbDeposito.Size = New System.Drawing.Size(49, 13)
        Me.chbDeposito.TabIndex = 3
        Me.chbDeposito.Text = "Depósito"
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
        Me.cmbSucursal.Location = New System.Drawing.Point(113, -1)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(126, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(38, 3)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbMostrarPrecio
        '
        Me.cmbMostrarPrecio.BindearPropiedadControl = Nothing
        Me.cmbMostrarPrecio.BindearPropiedadEntidad = Nothing
        Me.cmbMostrarPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMostrarPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMostrarPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMostrarPrecio.FormattingEnabled = True
        Me.cmbMostrarPrecio.IsPK = False
        Me.cmbMostrarPrecio.IsRequired = False
        Me.cmbMostrarPrecio.Key = Nothing
        Me.cmbMostrarPrecio.LabelAsoc = Me.lblMostrarPrecio
        Me.cmbMostrarPrecio.Location = New System.Drawing.Point(629, 52)
        Me.cmbMostrarPrecio.Name = "cmbMostrarPrecio"
        Me.cmbMostrarPrecio.Size = New System.Drawing.Size(176, 21)
        Me.cmbMostrarPrecio.TabIndex = 21
        '
        'lblMostrarPrecio
        '
        Me.lblMostrarPrecio.AutoSize = True
        Me.lblMostrarPrecio.LabelAsoc = Nothing
        Me.lblMostrarPrecio.Location = New System.Drawing.Point(549, 56)
        Me.lblMostrarPrecio.Name = "lblMostrarPrecio"
        Me.lblMostrarPrecio.Size = New System.Drawing.Size(74, 13)
        Me.lblMostrarPrecio.TabIndex = 20
        Me.lblMostrarPrecio.Text = "Mostrar precio"
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(811, 54)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 22
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Nothing
        Me.bscProveedor.Location = New System.Drawing.Point(209, 26)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = False
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(322, 20)
        Me.bscProveedor.TabIndex = 17
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
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(113, 26)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = False
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(93, 20)
        Me.bscCodigoProveedor.TabIndex = 16
        '
        'chbEmbalaje
        '
        Me.chbEmbalaje.AutoSize = True
        Me.chbEmbalaje.BindearPropiedadControl = Nothing
        Me.chbEmbalaje.BindearPropiedadEntidad = Nothing
        Me.chbEmbalaje.Enabled = False
        Me.chbEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmbalaje.IsPK = False
        Me.chbEmbalaje.IsRequired = False
        Me.chbEmbalaje.Key = Nothing
        Me.chbEmbalaje.LabelAsoc = Nothing
        Me.chbEmbalaje.Location = New System.Drawing.Point(615, 28)
        Me.chbEmbalaje.Name = "chbEmbalaje"
        Me.chbEmbalaje.Size = New System.Drawing.Size(220, 17)
        Me.chbEmbalaje.TabIndex = 19
        Me.chbEmbalaje.Text = "Mostrar Código del Proveedor y Embalaje"
        Me.chbEmbalaje.UseVisualStyleBackColor = True
        '
        'chbProveedorHabitual
        '
        Me.chbProveedorHabitual.AutoSize = True
        Me.chbProveedorHabitual.BindearPropiedadControl = Nothing
        Me.chbProveedorHabitual.BindearPropiedadEntidad = Nothing
        Me.chbProveedorHabitual.Enabled = False
        Me.chbProveedorHabitual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedorHabitual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedorHabitual.IsPK = False
        Me.chbProveedorHabitual.IsRequired = False
        Me.chbProveedorHabitual.Key = Nothing
        Me.chbProveedorHabitual.LabelAsoc = Nothing
        Me.chbProveedorHabitual.Location = New System.Drawing.Point(535, 28)
        Me.chbProveedorHabitual.Name = "chbProveedorHabitual"
        Me.chbProveedorHabitual.Size = New System.Drawing.Size(65, 17)
        Me.chbProveedorHabitual.TabIndex = 18
        Me.chbProveedorHabitual.Text = "Habitual"
        Me.chbProveedorHabitual.UseVisualStyleBackColor = True
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
        Me.chbProveedor.Location = New System.Drawing.Point(22, 28)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 15
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubSubRubros)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 86)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1072, 48)
        Me.FlowLayoutPanel1.TabIndex = 30
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
        Me.lblSubSubRubros.Location = New System.Drawing.Point(3, 3)
        Me.lblSubSubRubros.Name = "lblSubSubRubros"
        Me.lblSubSubRubros.Size = New System.Drawing.Size(79, 13)
        Me.lblSubSubRubros.TabIndex = 0
        Me.lblSubSubRubros.Text = "SubSubRubros"
        '
        'btnConsultar
        '
        Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
        Me.btnConsultar.AnchoredControl = Me.ugDetalle
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(958, 5)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 0
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance2
        UltraGridColumn31.Header.Caption = "Código"
        UltraGridColumn31.Header.VisiblePosition = 4
        UltraGridColumn31.Width = 70
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn32.Header.Caption = "Producto"
        UltraGridColumn32.Header.VisiblePosition = 5
        UltraGridColumn32.Width = 250
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance3
        UltraGridColumn33.Header.Caption = "E."
        UltraGridColumn33.Header.VisiblePosition = 0
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 25
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn34.Header.Caption = "Empresa"
        UltraGridColumn34.Header.VisiblePosition = 1
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 100
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance4
        UltraGridColumn1.Header.Caption = "S."
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 25
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.Header.Caption = "Sucursal"
        UltraGridColumn35.Header.VisiblePosition = 3
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 100
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance5
        UltraGridColumn36.Header.Caption = "D."
        UltraGridColumn36.Header.VisiblePosition = 6
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 25
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn54.CellAppearance = Appearance6
        UltraGridColumn54.Header.Caption = "Código Depósito"
        UltraGridColumn54.Header.VisiblePosition = 7
        UltraGridColumn54.Width = 70
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.Header.Caption = "Depósito"
        UltraGridColumn37.Header.VisiblePosition = 8
        UltraGridColumn37.Width = 100
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn38.CellAppearance = Appearance7
        UltraGridColumn38.Header.Caption = "U."
        UltraGridColumn38.Header.VisiblePosition = 9
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.Width = 25
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn55.CellAppearance = Appearance8
        UltraGridColumn55.Header.Caption = "Código Ubicación"
        UltraGridColumn55.Header.VisiblePosition = 10
        UltraGridColumn55.Width = 70
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn39.Header.Caption = "Ubicación"
        UltraGridColumn39.Header.VisiblePosition = 11
        UltraGridColumn39.Width = 100
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance9
        UltraGridColumn40.Header.Caption = "Tamaño"
        UltraGridColumn40.Header.VisiblePosition = 12
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.Width = 60
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn41.Header.Caption = "UndMed."
        UltraGridColumn41.Header.VisiblePosition = 13
        UltraGridColumn41.Hidden = True
        UltraGridColumn41.Width = 60
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn42.CellAppearance = Appearance10
        UltraGridColumn42.Header.VisiblePosition = 14
        UltraGridColumn42.Hidden = True
        UltraGridColumn42.Width = 50
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn43.CellAppearance = Appearance11
        UltraGridColumn43.Header.VisiblePosition = 17
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.Width = 50
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance12
        UltraGridColumn44.Header.VisiblePosition = 19
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Width = 50
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance13
        UltraGridColumn45.Header.VisiblePosition = 21
        UltraGridColumn45.Hidden = True
        UltraGridColumn45.Width = 50
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn46.CellAppearance = Appearance14
        UltraGridColumn46.Header.VisiblePosition = 23
        UltraGridColumn46.Hidden = True
        UltraGridColumn46.Width = 50
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn47.Header.Caption = "Marca"
        UltraGridColumn47.Header.VisiblePosition = 16
        UltraGridColumn47.Width = 100
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn48.Header.Caption = "Modelo"
        UltraGridColumn48.Header.VisiblePosition = 18
        UltraGridColumn48.Width = 100
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn49.Header.Caption = "Rubro"
        UltraGridColumn49.Header.VisiblePosition = 20
        UltraGridColumn49.Width = 100
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn50.Header.Caption = "SubRubro"
        UltraGridColumn50.Header.VisiblePosition = 22
        UltraGridColumn50.Width = 100
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn51.Header.Caption = "SubSubRubro"
        UltraGridColumn51.Header.VisiblePosition = 24
        UltraGridColumn51.Width = 100
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn52.CellAppearance = Appearance15
        UltraGridColumn52.Format = "N2"
        UltraGridColumn52.Header.VisiblePosition = 15
        UltraGridColumn52.Width = 100
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn53.CellAppearance = Appearance16
        UltraGridColumn53.Format = "N2"
        UltraGridColumn53.Header.VisiblePosition = 26
        UltraGridColumn53.Hidden = True
        UltraGridColumn53.Width = 100
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance17
        UltraGridColumn17.Format = "N2"
        UltraGridColumn17.Header.Caption = "Precio"
        UltraGridColumn17.Header.VisiblePosition = 27
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 90
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance18
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "Precio Costo"
        UltraGridColumn19.Header.VisiblePosition = 28
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 90
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance19
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "Precio Venta"
        UltraGridColumn18.Header.VisiblePosition = 25
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 90
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance20
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.Caption = "Precio Costo"
        UltraGridColumn20.Header.VisiblePosition = 29
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 90
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn56.CellAppearance = Appearance21
        UltraGridColumn56.Format = "N2"
        UltraGridColumn56.Header.Caption = "Precio Venta"
        UltraGridColumn56.Header.VisiblePosition = 30
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance22.TextHAlignAsString = "Left"
        UltraGridColumn15.CellAppearance = Appearance22
        UltraGridColumn15.Header.Caption = "Cód. Prod. Proveedor"
        UltraGridColumn15.Header.VisiblePosition = 32
        UltraGridColumn15.Width = 120
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance23
        UltraGridColumn16.Header.Caption = "Emb."
        UltraGridColumn16.Header.VisiblePosition = 31
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 35
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance24.TextHAlignAsString = "Left"
        UltraGridColumn22.CellAppearance = Appearance24
        UltraGridColumn22.Header.Caption = "Proveedor Habitual"
        UltraGridColumn22.Header.VisiblePosition = 33
        UltraGridColumn22.Width = 150
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance25.TextHAlignAsString = "Left"
        UltraGridColumn23.CellAppearance = Appearance25
        UltraGridColumn23.Header.Caption = "Cód. Prod. Proveedor Habitual"
        UltraGridColumn23.Header.VisiblePosition = 34
        UltraGridColumn23.Width = 120
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn29.Header.VisiblePosition = 36
        UltraGridColumn29.Hidden = True
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.VisiblePosition = 37
        UltraGridColumn27.Hidden = True
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn30.Header.VisiblePosition = 38
        UltraGridColumn30.Hidden = True
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.VisiblePosition = 39
        UltraGridColumn28.Hidden = True
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.VisiblePosition = 35
        UltraGridColumn24.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn1, UltraGridColumn35, UltraGridColumn36, UltraGridColumn54, UltraGridColumn37, UltraGridColumn38, UltraGridColumn55, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn17, UltraGridColumn19, UltraGridColumn18, UltraGridColumn20, UltraGridColumn56, UltraGridColumn15, UltraGridColumn16, UltraGridColumn22, UltraGridColumn23, UltraGridColumn29, UltraGridColumn27, UltraGridColumn30, UltraGridColumn28, UltraGridColumn24})
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
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(2, 2)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1072, 297)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1084, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1005, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
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
        'tbcInformeStock
        '
        Me.tbcInformeStock.Controls.Add(Me.tbpStock)
        Me.tbcInformeStock.Controls.Add(Me.tbpAtributoProducto)
        Me.tbcInformeStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcInformeStock.Location = New System.Drawing.Point(0, 212)
        Me.tbcInformeStock.Margin = New System.Windows.Forms.Padding(2)
        Me.tbcInformeStock.Name = "tbcInformeStock"
        Me.tbcInformeStock.Padding = New System.Drawing.Point(0, 0)
        Me.tbcInformeStock.SelectedIndex = 0
        Me.tbcInformeStock.Size = New System.Drawing.Size(1084, 327)
        Me.tbcInformeStock.TabIndex = 1
        '
        'tbpStock
        '
        Me.tbpStock.BackColor = System.Drawing.SystemColors.Control
        Me.tbpStock.Controls.Add(Me.btnConsultar)
        Me.tbpStock.Controls.Add(Me.ugDetalle)
        Me.tbpStock.Location = New System.Drawing.Point(4, 22)
        Me.tbpStock.Margin = New System.Windows.Forms.Padding(2)
        Me.tbpStock.Name = "tbpStock"
        Me.tbpStock.Padding = New System.Windows.Forms.Padding(2)
        Me.tbpStock.Size = New System.Drawing.Size(1076, 301)
        Me.tbpStock.TabIndex = 1
        Me.tbpStock.Text = "Stock"
        '
        'tbpAtributoProducto
        '
        Me.tbpAtributoProducto.BackColor = System.Drawing.Color.Transparent
        Me.tbpAtributoProducto.Controls.Add(Me.ugStockAtributo)
        Me.tbpAtributoProducto.Location = New System.Drawing.Point(4, 22)
        Me.tbpAtributoProducto.Name = "tbpAtributoProducto"
        Me.tbpAtributoProducto.Size = New System.Drawing.Size(1076, 301)
        Me.tbpAtributoProducto.TabIndex = 2
        Me.tbpAtributoProducto.Text = "-"
        Me.tbpAtributoProducto.UseVisualStyleBackColor = True
        '
        'ugStockAtributo
        '
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugStockAtributo.DisplayLayout.Appearance = Appearance38
        UltraGridColumn25.Header.VisiblePosition = 0
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.VisiblePosition = 1
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn25, UltraGridColumn26})
        Me.ugStockAtributo.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugStockAtributo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockAtributo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance39.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance39.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockAtributo.DisplayLayout.GroupByBox.Appearance = Appearance39
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockAtributo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance40
        Me.ugStockAtributo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockAtributo.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance41.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance41.BackColor2 = System.Drawing.SystemColors.Control
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance41.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockAtributo.DisplayLayout.GroupByBox.PromptAppearance = Appearance41
        Me.ugStockAtributo.DisplayLayout.MaxColScrollRegions = 1
        Me.ugStockAtributo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Appearance42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugStockAtributo.DisplayLayout.Override.ActiveCellAppearance = Appearance42
        Appearance43.BackColor = System.Drawing.SystemColors.Highlight
        Appearance43.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugStockAtributo.DisplayLayout.Override.ActiveRowAppearance = Appearance43
        Me.ugStockAtributo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugStockAtributo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockAtributo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugStockAtributo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Me.ugStockAtributo.DisplayLayout.Override.CardAreaAppearance = Appearance44
        Appearance45.BorderColor = System.Drawing.Color.Silver
        Appearance45.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugStockAtributo.DisplayLayout.Override.CellAppearance = Appearance45
        Me.ugStockAtributo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugStockAtributo.DisplayLayout.Override.CellPadding = 0
        Appearance46.BackColor = System.Drawing.SystemColors.Control
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockAtributo.DisplayLayout.Override.GroupByRowAppearance = Appearance46
        Appearance47.TextHAlignAsString = "Left"
        Me.ugStockAtributo.DisplayLayout.Override.HeaderAppearance = Appearance47
        Me.ugStockAtributo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugStockAtributo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance48.BackColor = System.Drawing.SystemColors.Window
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Me.ugStockAtributo.DisplayLayout.Override.RowAppearance = Appearance48
        Me.ugStockAtributo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockAtributo.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugStockAtributo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance49
        Me.ugStockAtributo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugStockAtributo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugStockAtributo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugStockAtributo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugStockAtributo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugStockAtributo.Location = New System.Drawing.Point(0, 0)
        Me.ugStockAtributo.Name = "ugStockAtributo"
        Me.ugStockAtributo.Size = New System.Drawing.Size(1076, 301)
        Me.ugStockAtributo.TabIndex = 89
        Me.ugStockAtributo.ToolStripLabelRegistros = Nothing
        Me.ugStockAtributo.ToolStripMenuExpandir = Nothing
        '
        'InformedeStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 561)
        Me.Controls.Add(Me.tbcInformeStock)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "InformedeStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Stock"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tbcInformeStock.ResumeLayout(False)
        Me.tbpStock.ResumeLayout(False)
        Me.tbpAtributoProducto.ResumeLayout(False)
        CType(Me.ugStockAtributo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoInforme As Eniac.Controles.ComboBox
    Friend WithEvents lblTipoInforme As Eniac.Controles.Label
    Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
    Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
    Friend WithEvents chbProveedorHabitual As Eniac.Controles.CheckBox
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnConsultar As ButtonConsultar
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents chbEmbalaje As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Controles.Buscador2
   Friend WithEvents bscProveedor As Controles.Buscador2
   Friend WithEvents cmbOrdenadoPor As Controles.ComboBox
   Friend WithEvents lblOrdenadoPor As Controles.Label
   Friend WithEvents cmbMostrarPrecio As Controles.ComboBox
   Friend WithEvents lblMostrarPrecio As Controles.Label
   Friend WithEvents cmbSucursal As ComboBoxSucursales
   Friend WithEvents lblSucursal As Controles.Label
   Friend WithEvents tbcInformeStock As TabControl
   Friend WithEvents tbpStock As TabPage
   Friend WithEvents tbpAtributoProducto As TabPage
   Friend WithEvents ugStockAtributo As UltraGridSiga
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents chbDeposito As Controles.Label
   Friend WithEvents cmbDepositos As ComboBoxDepositos
   Friend WithEvents lblStockUnificadoPor As Controles.Label
   Friend WithEvents cmbTipoDeposito As Controles.ComboBox
   Friend WithEvents chbTipoDeposito As Controles.CheckBox
    Friend WithEvents bscProducto2 As Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
    Friend WithEvents chbProducto As Controles.CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbStockUnificadoPor As Controles.ComboBox
End Class
