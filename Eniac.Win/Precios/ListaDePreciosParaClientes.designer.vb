<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDePreciosParaClientes
   Inherits BaseForm

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
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSucursal")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Tamano")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdMarca")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdRubro")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUnidadDeMedida")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioFabrica")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioCosto")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Foto")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioFabrica")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Foto")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Embalaje")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Simbolo")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaConIVA")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaSinIVA")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescRecProducto")
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta1")
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta2")
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta3")
      Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta4")
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta5")
      Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc1")
      Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc2")
      Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc3")
      Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc4")
      Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc5")
      Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubSubRubro")
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubSubRubro")
      Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCorto")
      Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ActualizaPreciosSucursalesAsociadas")
      Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMoneda")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoNumerico")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida2")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVigencia")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsOferta", 0)
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaDePreciosParaClientes))
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.chbAgregarPrecioEmbalaje = New Eniac.Controles.CheckBox()
        Me.grbMonedaCliente = New System.Windows.Forms.GroupBox()
        Me.cmbPrecio = New Eniac.Controles.ComboBox()
        Me.lblMoneda = New Eniac.Controles.Label()
        Me.lblPrecio = New Eniac.Controles.Label()
        Me.chbProductosCliente = New Eniac.Controles.CheckBox()
        Me.bscCliente2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoCliente2 = New Eniac.Controles.Buscador2()
        Me.cmbMoneda = New Eniac.Controles.ComboBox()
        Me.txtTipoCambio = New Eniac.Controles.TextBox()
        Me.lblTipoCambio = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.optOrdenarPorNombre = New System.Windows.Forms.RadioButton()
        Me.optOrdenarPorCodigo = New System.Windows.Forms.RadioButton()
        Me.chbCondensado = New Eniac.Controles.CheckBox()
        Me.optAgruparPorMarcaRubro = New System.Windows.Forms.RadioButton()
        Me.optAgruparPorMarca = New System.Windows.Forms.RadioButton()
        Me.optAgruparPorRubroMarca = New System.Windows.Forms.RadioButton()
        Me.optAgruparPorRubro = New System.Windows.Forms.RadioButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbSSubRubro = New Eniac.Win.ComboBoxSubSubRubro()
        Me.lblSSubRubro = New Eniac.Controles.Label()
        Me.grpPublicarEn = New System.Windows.Forms.GroupBox()
        Me.cmbPublicarEnEmpresarial = New Eniac.Controles.ComboBox()
        Me.cmbPublicarEnGestion = New Eniac.Controles.ComboBox()
        Me.cmbPublicarEnWeb = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnEmpresarial = New System.Windows.Forms.Label()
        Me.cmbPublicarEnSincronizarSucursal = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnSincronizacionSucursal = New Eniac.Controles.Label()
        Me.cmbPublicarEnBalanza = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnBalanza = New Eniac.Controles.Label()
        Me.cmbPublicarEnListaDePreciosParaClientes = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnListaDePreciosParaClientes = New Eniac.Controles.Label()
        Me.lblPublicarEnGestion = New System.Windows.Forms.Label()
        Me.lblPublicarEnWeb = New System.Windows.Forms.Label()
        Me.chbFechaActualizado = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.lblCodigoProducto = New Eniac.Controles.Label()
        Me.txtCodigoProducto = New Eniac.Controles.TextBox()
        Me.lblNombreProducto = New Eniac.Controles.Label()
        Me.txtNombreProducto = New Eniac.Controles.TextBox()
        Me.lblSubRubro = New Eniac.Controles.Label()
        Me.cmbSubRubro = New Eniac.Win.ComboBoxSubRubro()
        Me.lblRubro = New Eniac.Controles.Label()
        Me.lblMarca = New Eniac.Controles.Label()
        Me.cmbRubro = New Eniac.Win.ComboBoxRubro()
        Me.cmbMarca = New Eniac.Win.ComboBoxMarcas()
        Me.cmbEsOferta = New Eniac.Controles.ComboBox()
        Me.lblEsOferta = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbConStock = New Eniac.Controles.CheckBox()
        Me.chbConPrecio = New Eniac.Controles.CheckBox()
        Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
        Me.lblListaPrecios = New Eniac.Controles.Label()
        Me.chbConImagen = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.pnlCodigoDescripcion = New System.Windows.Forms.FlowLayoutPanel()
        Me.radCodigoYDescripcion = New System.Windows.Forms.RadioButton()
        Me.radCodigoODescripcion = New System.Windows.Forms.RadioButton()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.chb2Columnas = New Eniac.Controles.CheckBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.rbRubroSubRubro = New System.Windows.Forms.RadioButton()
        Me.rbSubRubro = New System.Windows.Forms.RadioButton()
        Me.rbMarcaRubroSubRubro = New System.Windows.Forms.RadioButton()
        Me.gbAgruparPor = New System.Windows.Forms.GroupBox()
        Me.rbRubroSubRubroSubSubRubro = New System.Windows.Forms.RadioButton()
        Me.gbOrdenarPor = New System.Windows.Forms.GroupBox()
        Me.rbCodNumerico = New System.Windows.Forms.RadioButton()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbMonedaCliente.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.grpPublicarEn.SuspendLayout()
        Me.pnlCodigoDescripcion.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.gbAgruparPor.SuspendLayout()
        Me.gbOrdenarPor.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource1
        '
        UltraDataColumn14.DataType = GetType(System.Drawing.Bitmap)
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14})
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Lista de Precios Múltiples"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance21
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
        UltraGridColumn42.Header.VisiblePosition = 0
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.Header.VisiblePosition = 1
        UltraGridColumn43.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance2
        UltraGridColumn44.Header.Caption = "Codigo"
        UltraGridColumn44.Header.VisiblePosition = 7
        UltraGridColumn44.Width = 77
        UltraGridColumn45.Header.Caption = "Nombre Producto"
        UltraGridColumn45.Header.VisiblePosition = 8
        UltraGridColumn45.Width = 259
        UltraGridColumn46.Header.VisiblePosition = 2
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.Header.VisiblePosition = 3
        UltraGridColumn47.Hidden = True
        UltraGridColumn48.Header.VisiblePosition = 4
        UltraGridColumn48.Hidden = True
        UltraGridColumn49.Header.Caption = "Marca"
        UltraGridColumn49.Header.VisiblePosition = 12
        UltraGridColumn49.Width = 121
        UltraGridColumn50.Header.VisiblePosition = 5
        UltraGridColumn50.Hidden = True
        UltraGridColumn51.Header.Caption = "Rubro"
        UltraGridColumn51.Header.VisiblePosition = 14
        UltraGridColumn51.Width = 121
        UltraGridColumn52.Header.VisiblePosition = 6
        UltraGridColumn52.Hidden = True
        UltraGridColumn53.Header.Caption = "Subrubro"
        UltraGridColumn53.Header.VisiblePosition = 15
        UltraGridColumn53.Hidden = True
        UltraGridColumn53.Width = 150
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn54.CellAppearance = Appearance3
        UltraGridColumn54.Header.Caption = "Cód. Producto Proveedor"
        UltraGridColumn54.Header.VisiblePosition = 36
        UltraGridColumn54.Width = 132
        UltraGridColumn55.Header.VisiblePosition = 9
        UltraGridColumn55.Hidden = True
        UltraGridColumn56.Header.VisiblePosition = 13
        UltraGridColumn56.Hidden = True
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn57.CellAppearance = Appearance4
        UltraGridColumn57.Format = "##,##0.00"
        UltraGridColumn57.Header.Caption = "Precio Venta"
        UltraGridColumn57.Header.VisiblePosition = 19
        UltraGridColumn57.Hidden = True
        UltraGridColumn57.Width = 80
        UltraGridColumn58.Header.VisiblePosition = 20
        UltraGridColumn58.Hidden = True
        UltraGridColumn58.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn59.CellAppearance = Appearance5
        UltraGridColumn59.Format = "N2"
        UltraGridColumn59.Header.VisiblePosition = 10
        UltraGridColumn59.Hidden = True
        UltraGridColumn59.Width = 50
        UltraGridColumn60.Header.VisiblePosition = 11
        UltraGridColumn60.Hidden = True
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn61.CellAppearance = Appearance6
        UltraGridColumn61.Header.Caption = ""
        UltraGridColumn61.Header.VisiblePosition = 17
        UltraGridColumn61.Width = 35
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn62.CellAppearance = Appearance7
        UltraGridColumn62.Format = "##,##0.00"
        UltraGridColumn62.Header.Caption = "Precio c/ IVA"
        UltraGridColumn62.Header.VisiblePosition = 21
        UltraGridColumn62.Width = 80
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn63.CellAppearance = Appearance8
        UltraGridColumn63.Format = "##,##0.00"
        UltraGridColumn63.Header.Caption = "Precio s/ IVA"
        UltraGridColumn63.Header.VisiblePosition = 22
        UltraGridColumn63.Width = 80
        UltraGridColumn64.Header.VisiblePosition = 23
        UltraGridColumn64.Hidden = True
        UltraGridColumn65.Header.VisiblePosition = 24
        UltraGridColumn65.Hidden = True
        UltraGridColumn66.Header.VisiblePosition = 25
        UltraGridColumn66.Hidden = True
        UltraGridColumn67.Header.VisiblePosition = 26
        UltraGridColumn67.Hidden = True
        UltraGridColumn68.Header.VisiblePosition = 27
        UltraGridColumn68.Hidden = True
        UltraGridColumn69.Header.VisiblePosition = 28
        UltraGridColumn69.Hidden = True
        UltraGridColumn70.Header.VisiblePosition = 29
        UltraGridColumn70.Hidden = True
        UltraGridColumn71.Header.VisiblePosition = 30
        UltraGridColumn71.Hidden = True
        UltraGridColumn72.Header.VisiblePosition = 31
        UltraGridColumn72.Hidden = True
        UltraGridColumn73.Header.VisiblePosition = 32
        UltraGridColumn73.Hidden = True
        UltraGridColumn74.Header.VisiblePosition = 33
        UltraGridColumn74.Hidden = True
        UltraGridColumn75.Header.VisiblePosition = 34
        UltraGridColumn75.Hidden = True
        UltraGridColumn76.Header.Caption = "SubSubRubro"
        UltraGridColumn76.Header.VisiblePosition = 35
        UltraGridColumn76.Hidden = True
        UltraGridColumn77.Format = "dd/MM/yyyy HH:mm:ss"
        UltraGridColumn77.Header.Caption = "Actualizado"
        UltraGridColumn77.Header.VisiblePosition = 16
        UltraGridColumn77.Width = 111
        UltraGridColumn78.Header.VisiblePosition = 37
        UltraGridColumn78.Hidden = True
        UltraGridColumn79.Header.VisiblePosition = 38
        UltraGridColumn79.Hidden = True
        UltraGridColumn80.Header.VisiblePosition = 39
        UltraGridColumn80.Hidden = True
        UltraGridColumn1.Header.Caption = "Cód. Producto Numérico"
        UltraGridColumn1.Header.VisiblePosition = 40
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.Caption = "Unidad Medida 2"
        UltraGridColumn2.Header.VisiblePosition = 41
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.VisiblePosition = 42
        UltraGridColumn3.Hidden = True
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn81.CellAppearance = Appearance9
        UltraGridColumn81.Header.Caption = "Es Oferta"
        UltraGridColumn81.Header.VisiblePosition = 18
        UltraGridColumn81.Width = 43
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn81})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance10
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance12.BackColor2 = System.Drawing.SystemColors.Control
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.SystemColors.Highlight
        Appearance14.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance16
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance17.BackColor = System.Drawing.SystemColors.Control
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance17
        Appearance18.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance18
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(8, 355)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(968, 174)
        Me.ugDetalle.TabIndex = 0
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'chbAgregarPrecioEmbalaje
        '
        Me.chbAgregarPrecioEmbalaje.AutoSize = True
        Me.chbAgregarPrecioEmbalaje.BindearPropiedadControl = Nothing
        Me.chbAgregarPrecioEmbalaje.BindearPropiedadEntidad = Nothing
        Me.chbAgregarPrecioEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAgregarPrecioEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAgregarPrecioEmbalaje.IsPK = False
        Me.chbAgregarPrecioEmbalaje.IsRequired = False
        Me.chbAgregarPrecioEmbalaje.Key = Nothing
        Me.chbAgregarPrecioEmbalaje.LabelAsoc = Nothing
        Me.chbAgregarPrecioEmbalaje.Location = New System.Drawing.Point(598, 16)
        Me.chbAgregarPrecioEmbalaje.Name = "chbAgregarPrecioEmbalaje"
        Me.chbAgregarPrecioEmbalaje.Size = New System.Drawing.Size(142, 17)
        Me.chbAgregarPrecioEmbalaje.TabIndex = 5
        Me.chbAgregarPrecioEmbalaje.Text = "Agregar Precio Embalaje"
        Me.chbAgregarPrecioEmbalaje.UseVisualStyleBackColor = True
        '
        'grbMonedaCliente
        '
        Me.grbMonedaCliente.Controls.Add(Me.cmbPrecio)
        Me.grbMonedaCliente.Controls.Add(Me.lblPrecio)
        Me.grbMonedaCliente.Controls.Add(Me.chbProductosCliente)
        Me.grbMonedaCliente.Controls.Add(Me.bscCliente2)
        Me.grbMonedaCliente.Controls.Add(Me.bscCodigoCliente2)
        Me.grbMonedaCliente.Controls.Add(Me.cmbMoneda)
        Me.grbMonedaCliente.Controls.Add(Me.txtTipoCambio)
        Me.grbMonedaCliente.Controls.Add(Me.lblMoneda)
        Me.grbMonedaCliente.Controls.Add(Me.chbCliente)
        Me.grbMonedaCliente.Controls.Add(Me.lblTipoCambio)
        Me.grbMonedaCliente.Location = New System.Drawing.Point(498, 252)
        Me.grbMonedaCliente.Name = "grbMonedaCliente"
        Me.grbMonedaCliente.Size = New System.Drawing.Size(478, 74)
        Me.grbMonedaCliente.TabIndex = 6
        Me.grbMonedaCliente.TabStop = False
        '
        'cmbPrecio
        '
        Me.cmbPrecio.BindearPropiedadControl = Nothing
        Me.cmbPrecio.BindearPropiedadEntidad = Nothing
        Me.cmbPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPrecio.FormattingEnabled = True
        Me.cmbPrecio.IsPK = False
        Me.cmbPrecio.IsRequired = False
        Me.cmbPrecio.Items.AddRange(New Object() {"de venta", "por embalaje"})
        Me.cmbPrecio.Key = Nothing
        Me.cmbPrecio.LabelAsoc = Me.lblMoneda
        Me.cmbPrecio.Location = New System.Drawing.Point(278, 13)
        Me.cmbPrecio.Name = "cmbPrecio"
        Me.cmbPrecio.Size = New System.Drawing.Size(89, 21)
        Me.cmbPrecio.TabIndex = 5
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(4, 17)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblMoneda.TabIndex = 0
        Me.lblMoneda.Text = "Moneda"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.LabelAsoc = Nothing
        Me.lblPrecio.Location = New System.Drawing.Point(243, 17)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 4
        Me.lblPrecio.Text = "Precio"
        '
        'chbProductosCliente
        '
        Me.chbProductosCliente.AutoSize = True
        Me.chbProductosCliente.BindearPropiedadControl = Nothing
        Me.chbProductosCliente.BindearPropiedadEntidad = Nothing
        Me.chbProductosCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductosCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductosCliente.IsPK = False
        Me.chbProductosCliente.IsRequired = False
        Me.chbProductosCliente.Key = Nothing
        Me.chbProductosCliente.LabelAsoc = Nothing
        Me.chbProductosCliente.Location = New System.Drawing.Point(371, 15)
        Me.chbProductosCliente.Name = "chbProductosCliente"
        Me.chbProductosCliente.Size = New System.Drawing.Size(104, 17)
        Me.chbProductosCliente.TabIndex = 6
        Me.chbProductosCliente.Text = "Producto Cliente"
        Me.chbProductosCliente.UseVisualStyleBackColor = True
        '
        'bscCliente2
        '
        Me.bscCliente2.ActivarFiltroEnGrilla = True
        Me.bscCliente2.AutoSize = True
        Me.bscCliente2.BindearPropiedadControl = Nothing
        Me.bscCliente2.BindearPropiedadEntidad = Nothing
        Me.bscCliente2.ConfigBuscador = Nothing
        Me.bscCliente2.Datos = Nothing
        Me.bscCliente2.Enabled = False
        Me.bscCliente2.FilaDevuelta = Nothing
        Me.bscCliente2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente2.IsDecimal = False
        Me.bscCliente2.IsNumber = False
        Me.bscCliente2.IsPK = False
        Me.bscCliente2.IsRequired = False
        Me.bscCliente2.Key = ""
        Me.bscCliente2.LabelAsoc = Nothing
        Me.bscCliente2.Location = New System.Drawing.Point(164, 40)
        Me.bscCliente2.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente2.MaxLengh = "32767"
        Me.bscCliente2.Name = "bscCliente2"
        Me.bscCliente2.Permitido = True
        Me.bscCliente2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente2.Selecciono = False
        Me.bscCliente2.Size = New System.Drawing.Size(300, 27)
        Me.bscCliente2.TabIndex = 9
        '
        'bscCodigoCliente2
        '
        Me.bscCodigoCliente2.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente2.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente2.ConfigBuscador = Nothing
        Me.bscCodigoCliente2.Datos = Nothing
        Me.bscCodigoCliente2.Enabled = False
        Me.bscCodigoCliente2.FilaDevuelta = Nothing
        Me.bscCodigoCliente2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente2.IsDecimal = False
        Me.bscCodigoCliente2.IsNumber = True
        Me.bscCodigoCliente2.IsPK = False
        Me.bscCodigoCliente2.IsRequired = False
        Me.bscCodigoCliente2.Key = ""
        Me.bscCodigoCliente2.LabelAsoc = Nothing
        Me.bscCodigoCliente2.Location = New System.Drawing.Point(70, 40)
        Me.bscCodigoCliente2.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoCliente2.MaxLengh = "32767"
        Me.bscCodigoCliente2.Name = "bscCodigoCliente2"
        Me.bscCodigoCliente2.Permitido = True
        Me.bscCodigoCliente2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente2.Selecciono = False
        Me.bscCodigoCliente2.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente2.TabIndex = 8
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BindearPropiedadControl = Nothing
        Me.cmbMoneda.BindearPropiedadEntidad = Nothing
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.IsPK = False
        Me.cmbMoneda.IsRequired = False
        Me.cmbMoneda.Items.AddRange(New Object() {"del producto"})
        Me.cmbMoneda.Key = Nothing
        Me.cmbMoneda.LabelAsoc = Me.lblMoneda
        Me.cmbMoneda.Location = New System.Drawing.Point(49, 13)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(85, 21)
        Me.cmbMoneda.TabIndex = 1
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BindearPropiedadControl = ""
        Me.txtTipoCambio.BindearPropiedadEntidad = ""
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoCambio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoCambio.Formato = "N2"
        Me.txtTipoCambio.IsDecimal = True
        Me.txtTipoCambio.IsNumber = True
        Me.txtTipoCambio.IsPK = False
        Me.txtTipoCambio.IsRequired = False
        Me.txtTipoCambio.Key = ""
        Me.txtTipoCambio.LabelAsoc = Me.lblTipoCambio
        Me.txtTipoCambio.Location = New System.Drawing.Point(201, 13)
        Me.txtTipoCambio.MaxLength = 7
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(40, 20)
        Me.txtTipoCambio.TabIndex = 3
        Me.txtTipoCambio.Text = "1.00"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.LabelAsoc = Nothing
        Me.lblTipoCambio.Location = New System.Drawing.Point(133, 17)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(66, 13)
        Me.lblTipoCambio.TabIndex = 2
        Me.lblTipoCambio.Text = "Tipo Cambio"
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
        Me.chbCliente.Location = New System.Drawing.Point(7, 41)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 7
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'optOrdenarPorNombre
        '
        Me.optOrdenarPorNombre.AutoSize = True
        Me.optOrdenarPorNombre.Location = New System.Drawing.Point(6, 33)
        Me.optOrdenarPorNombre.Name = "optOrdenarPorNombre"
        Me.optOrdenarPorNombre.Size = New System.Drawing.Size(72, 17)
        Me.optOrdenarPorNombre.TabIndex = 1
        Me.optOrdenarPorNombre.TabStop = True
        Me.optOrdenarPorNombre.Text = "Alfabético"
        Me.optOrdenarPorNombre.UseVisualStyleBackColor = True
        '
        'optOrdenarPorCodigo
        '
        Me.optOrdenarPorCodigo.AutoSize = True
        Me.optOrdenarPorCodigo.Checked = True
        Me.optOrdenarPorCodigo.Location = New System.Drawing.Point(6, 15)
        Me.optOrdenarPorCodigo.Name = "optOrdenarPorCodigo"
        Me.optOrdenarPorCodigo.Size = New System.Drawing.Size(58, 17)
        Me.optOrdenarPorCodigo.TabIndex = 0
        Me.optOrdenarPorCodigo.TabStop = True
        Me.optOrdenarPorCodigo.Text = "Código"
        Me.optOrdenarPorCodigo.UseVisualStyleBackColor = True
        '
        'chbCondensado
        '
        Me.chbCondensado.AutoSize = True
        Me.chbCondensado.BindearPropiedadControl = Nothing
        Me.chbCondensado.BindearPropiedadEntidad = Nothing
        Me.chbCondensado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCondensado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCondensado.IsPK = False
        Me.chbCondensado.IsRequired = False
        Me.chbCondensado.Key = Nothing
        Me.chbCondensado.LabelAsoc = Nothing
        Me.chbCondensado.Location = New System.Drawing.Point(397, 332)
        Me.chbCondensado.Name = "chbCondensado"
        Me.chbCondensado.Size = New System.Drawing.Size(86, 17)
        Me.chbCondensado.TabIndex = 5
        Me.chbCondensado.Text = "Condensado"
        Me.chbCondensado.UseVisualStyleBackColor = True
        Me.chbCondensado.Visible = False
        '
        'optAgruparPorMarcaRubro
        '
        Me.optAgruparPorMarcaRubro.AutoSize = True
        Me.optAgruparPorMarcaRubro.Location = New System.Drawing.Point(82, 22)
        Me.optAgruparPorMarcaRubro.Name = "optAgruparPorMarcaRubro"
        Me.optAgruparPorMarcaRubro.Size = New System.Drawing.Size(96, 17)
        Me.optAgruparPorMarcaRubro.TabIndex = 1
        Me.optAgruparPorMarcaRubro.Text = "Marca _ Rubro"
        Me.optAgruparPorMarcaRubro.UseVisualStyleBackColor = True
        '
        'optAgruparPorMarca
        '
        Me.optAgruparPorMarca.AutoSize = True
        Me.optAgruparPorMarca.Checked = True
        Me.optAgruparPorMarca.Location = New System.Drawing.Point(7, 22)
        Me.optAgruparPorMarca.Name = "optAgruparPorMarca"
        Me.optAgruparPorMarca.Size = New System.Drawing.Size(55, 17)
        Me.optAgruparPorMarca.TabIndex = 0
        Me.optAgruparPorMarca.TabStop = True
        Me.optAgruparPorMarca.Text = "Marca"
        Me.optAgruparPorMarca.UseVisualStyleBackColor = True
        '
        'optAgruparPorRubroMarca
        '
        Me.optAgruparPorRubroMarca.AutoSize = True
        Me.optAgruparPorRubroMarca.Location = New System.Drawing.Point(82, 45)
        Me.optAgruparPorRubroMarca.Name = "optAgruparPorRubroMarca"
        Me.optAgruparPorRubroMarca.Size = New System.Drawing.Size(96, 17)
        Me.optAgruparPorRubroMarca.TabIndex = 4
        Me.optAgruparPorRubroMarca.Text = "Rubro _ Marca"
        Me.optAgruparPorRubroMarca.UseVisualStyleBackColor = True
        '
        'optAgruparPorRubro
        '
        Me.optAgruparPorRubro.AutoSize = True
        Me.optAgruparPorRubro.Location = New System.Drawing.Point(7, 45)
        Me.optAgruparPorRubro.Name = "optAgruparPorRubro"
        Me.optAgruparPorRubro.Size = New System.Drawing.Size(54, 17)
        Me.optAgruparPorRubro.TabIndex = 3
        Me.optAgruparPorRubro.Text = "Rubro"
        Me.optAgruparPorRubro.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 534)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 4
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
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbSSubRubro)
        Me.grbFiltros.Controls.Add(Me.lblSSubRubro)
        Me.grbFiltros.Controls.Add(Me.grpPublicarEn)
        Me.grbFiltros.Controls.Add(Me.chbFechaActualizado)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.lblCodigoProducto)
        Me.grbFiltros.Controls.Add(Me.txtCodigoProducto)
        Me.grbFiltros.Controls.Add(Me.lblNombreProducto)
        Me.grbFiltros.Controls.Add(Me.txtNombreProducto)
        Me.grbFiltros.Controls.Add(Me.lblSubRubro)
        Me.grbFiltros.Controls.Add(Me.cmbSubRubro)
        Me.grbFiltros.Controls.Add(Me.lblRubro)
        Me.grbFiltros.Controls.Add(Me.lblMarca)
        Me.grbFiltros.Controls.Add(Me.cmbRubro)
        Me.grbFiltros.Controls.Add(Me.cmbMarca)
        Me.grbFiltros.Controls.Add(Me.cmbEsOferta)
        Me.grbFiltros.Controls.Add(Me.lblEsOferta)
        Me.grbFiltros.Controls.Add(Me.bscProducto2)
        Me.grbFiltros.Controls.Add(Me.chbAgregarPrecioEmbalaje)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
        Me.grbFiltros.Controls.Add(Me.chbConStock)
        Me.grbFiltros.Controls.Add(Me.chbConPrecio)
        Me.grbFiltros.Controls.Add(Me.cmbListaDePrecios)
        Me.grbFiltros.Controls.Add(Me.lblListaPrecios)
        Me.grbFiltros.Controls.Add(Me.chbConImagen)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbProducto)
        Me.grbFiltros.Controls.Add(Me.pnlCodigoDescripcion)
        Me.grbFiltros.Location = New System.Drawing.Point(8, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(968, 192)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'cmbSSubRubro
        '
        Me.cmbSSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSSubRubro.ConcatenarNombreSubRubro = False
        Me.cmbSSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSSubRubro.FormattingEnabled = True
        Me.cmbSSubRubro.IsPK = False
        Me.cmbSSubRubro.IsRequired = False
        Me.cmbSSubRubro.Key = Nothing
        Me.cmbSSubRubro.LabelAsoc = Nothing
        Me.cmbSSubRubro.Location = New System.Drawing.Point(711, 68)
        Me.cmbSSubRubro.Name = "cmbSSubRubro"
        Me.cmbSSubRubro.Size = New System.Drawing.Size(141, 21)
        Me.cmbSSubRubro.TabIndex = 15
        '
        'lblSSubRubro
        '
        Me.lblSSubRubro.AutoSize = True
        Me.lblSSubRubro.LabelAsoc = Nothing
        Me.lblSSubRubro.Location = New System.Drawing.Point(632, 71)
        Me.lblSSubRubro.Name = "lblSSubRubro"
        Me.lblSSubRubro.Size = New System.Drawing.Size(74, 13)
        Me.lblSSubRubro.TabIndex = 14
        Me.lblSSubRubro.Text = "SubSubRubro"
        '
        'grpPublicarEn
        '
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnEmpresarial)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnGestion)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnWeb)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnEmpresarial)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnSincronizarSucursal)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnBalanza)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnSincronizacionSucursal)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnListaDePreciosParaClientes)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnBalanza)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnGestion)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnListaDePreciosParaClientes)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnWeb)
        Me.grpPublicarEn.Location = New System.Drawing.Point(554, 97)
        Me.grpPublicarEn.Name = "grpPublicarEn"
        Me.grpPublicarEn.Size = New System.Drawing.Size(402, 87)
        Me.grpPublicarEn.TabIndex = 29
        Me.grpPublicarEn.TabStop = False
        Me.grpPublicarEn.Text = "Publicar En..."
        '
        'cmbPublicarEnEmpresarial
        '
        Me.cmbPublicarEnEmpresarial.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnEmpresarial.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnEmpresarial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnEmpresarial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnEmpresarial.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnEmpresarial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnEmpresarial.FormattingEnabled = True
        Me.cmbPublicarEnEmpresarial.IsPK = False
        Me.cmbPublicarEnEmpresarial.IsRequired = False
        Me.cmbPublicarEnEmpresarial.Key = Nothing
        Me.cmbPublicarEnEmpresarial.LabelAsoc = Nothing
        Me.cmbPublicarEnEmpresarial.Location = New System.Drawing.Point(96, 61)
        Me.cmbPublicarEnEmpresarial.Name = "cmbPublicarEnEmpresarial"
        Me.cmbPublicarEnEmpresarial.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnEmpresarial.TabIndex = 5
        '
        'cmbPublicarEnGestion
        '
        Me.cmbPublicarEnGestion.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnGestion.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnGestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnGestion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnGestion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnGestion.FormattingEnabled = True
        Me.cmbPublicarEnGestion.IsPK = False
        Me.cmbPublicarEnGestion.IsRequired = False
        Me.cmbPublicarEnGestion.Key = Nothing
        Me.cmbPublicarEnGestion.LabelAsoc = Nothing
        Me.cmbPublicarEnGestion.Location = New System.Drawing.Point(96, 37)
        Me.cmbPublicarEnGestion.Name = "cmbPublicarEnGestion"
        Me.cmbPublicarEnGestion.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnGestion.TabIndex = 3
        '
        'cmbPublicarEnWeb
        '
        Me.cmbPublicarEnWeb.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnWeb.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnWeb.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnWeb.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnWeb.FormattingEnabled = True
        Me.cmbPublicarEnWeb.IsPK = False
        Me.cmbPublicarEnWeb.IsRequired = False
        Me.cmbPublicarEnWeb.Key = Nothing
        Me.cmbPublicarEnWeb.LabelAsoc = Nothing
        Me.cmbPublicarEnWeb.Location = New System.Drawing.Point(96, 13)
        Me.cmbPublicarEnWeb.Name = "cmbPublicarEnWeb"
        Me.cmbPublicarEnWeb.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnWeb.TabIndex = 1
        '
        'lblPublicarEnEmpresarial
        '
        Me.lblPublicarEnEmpresarial.AutoSize = True
        Me.lblPublicarEnEmpresarial.Location = New System.Drawing.Point(4, 65)
        Me.lblPublicarEnEmpresarial.Name = "lblPublicarEnEmpresarial"
        Me.lblPublicarEnEmpresarial.Size = New System.Drawing.Size(83, 13)
        Me.lblPublicarEnEmpresarial.TabIndex = 4
        Me.lblPublicarEnEmpresarial.Text = "App Empresarial"
        '
        'cmbPublicarEnSincronizarSucursal
        '
        Me.cmbPublicarEnSincronizarSucursal.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnSincronizarSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnSincronizarSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnSincronizarSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnSincronizarSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnSincronizarSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnSincronizarSucursal.FormattingEnabled = True
        Me.cmbPublicarEnSincronizarSucursal.IsPK = False
        Me.cmbPublicarEnSincronizarSucursal.IsRequired = False
        Me.cmbPublicarEnSincronizarSucursal.Key = Nothing
        Me.cmbPublicarEnSincronizarSucursal.LabelAsoc = Me.lblPublicarEnSincronizacionSucursal
        Me.cmbPublicarEnSincronizarSucursal.Location = New System.Drawing.Point(313, 37)
        Me.cmbPublicarEnSincronizarSucursal.Name = "cmbPublicarEnSincronizarSucursal"
        Me.cmbPublicarEnSincronizarSucursal.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnSincronizarSucursal.TabIndex = 9
        '
        'lblPublicarEnSincronizacionSucursal
        '
        Me.lblPublicarEnSincronizacionSucursal.AutoSize = True
        Me.lblPublicarEnSincronizacionSucursal.LabelAsoc = Nothing
        Me.lblPublicarEnSincronizacionSucursal.Location = New System.Drawing.Point(185, 41)
        Me.lblPublicarEnSincronizacionSucursal.Name = "lblPublicarEnSincronizacionSucursal"
        Me.lblPublicarEnSincronizacionSucursal.Size = New System.Drawing.Size(103, 13)
        Me.lblPublicarEnSincronizacionSucursal.TabIndex = 8
        Me.lblPublicarEnSincronizacionSucursal.Text = "Sincronizar Sucursal"
        '
        'cmbPublicarEnBalanza
        '
        Me.cmbPublicarEnBalanza.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnBalanza.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnBalanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnBalanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnBalanza.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnBalanza.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnBalanza.FormattingEnabled = True
        Me.cmbPublicarEnBalanza.IsPK = False
        Me.cmbPublicarEnBalanza.IsRequired = False
        Me.cmbPublicarEnBalanza.Key = Nothing
        Me.cmbPublicarEnBalanza.LabelAsoc = Me.lblPublicarEnBalanza
        Me.cmbPublicarEnBalanza.Location = New System.Drawing.Point(313, 13)
        Me.cmbPublicarEnBalanza.Name = "cmbPublicarEnBalanza"
        Me.cmbPublicarEnBalanza.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnBalanza.TabIndex = 7
        '
        'lblPublicarEnBalanza
        '
        Me.lblPublicarEnBalanza.AutoSize = True
        Me.lblPublicarEnBalanza.LabelAsoc = Nothing
        Me.lblPublicarEnBalanza.Location = New System.Drawing.Point(185, 17)
        Me.lblPublicarEnBalanza.Name = "lblPublicarEnBalanza"
        Me.lblPublicarEnBalanza.Size = New System.Drawing.Size(45, 13)
        Me.lblPublicarEnBalanza.TabIndex = 6
        Me.lblPublicarEnBalanza.Text = "Balanza"
        '
        'cmbPublicarEnListaDePreciosParaClientes
        '
        Me.cmbPublicarEnListaDePreciosParaClientes.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnListaDePreciosParaClientes.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnListaDePreciosParaClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnListaDePreciosParaClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnListaDePreciosParaClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnListaDePreciosParaClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnListaDePreciosParaClientes.FormattingEnabled = True
        Me.cmbPublicarEnListaDePreciosParaClientes.IsPK = False
        Me.cmbPublicarEnListaDePreciosParaClientes.IsRequired = False
        Me.cmbPublicarEnListaDePreciosParaClientes.Key = Nothing
        Me.cmbPublicarEnListaDePreciosParaClientes.LabelAsoc = Me.lblPublicarEnListaDePreciosParaClientes
        Me.cmbPublicarEnListaDePreciosParaClientes.Location = New System.Drawing.Point(313, 61)
        Me.cmbPublicarEnListaDePreciosParaClientes.Name = "cmbPublicarEnListaDePreciosParaClientes"
        Me.cmbPublicarEnListaDePreciosParaClientes.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnListaDePreciosParaClientes.TabIndex = 11
        '
        'lblPublicarEnListaDePreciosParaClientes
        '
        Me.lblPublicarEnListaDePreciosParaClientes.AutoSize = True
        Me.lblPublicarEnListaDePreciosParaClientes.LabelAsoc = Nothing
        Me.lblPublicarEnListaDePreciosParaClientes.Location = New System.Drawing.Point(185, 65)
        Me.lblPublicarEnListaDePreciosParaClientes.Name = "lblPublicarEnListaDePreciosParaClientes"
        Me.lblPublicarEnListaDePreciosParaClientes.Size = New System.Drawing.Size(122, 13)
        Me.lblPublicarEnListaDePreciosParaClientes.TabIndex = 10
        Me.lblPublicarEnListaDePreciosParaClientes.Text = "Lista de Precios Clientes"
        '
        'lblPublicarEnGestion
        '
        Me.lblPublicarEnGestion.AutoSize = True
        Me.lblPublicarEnGestion.Location = New System.Drawing.Point(4, 40)
        Me.lblPublicarEnGestion.Name = "lblPublicarEnGestion"
        Me.lblPublicarEnGestion.Size = New System.Drawing.Size(65, 13)
        Me.lblPublicarEnGestion.TabIndex = 2
        Me.lblPublicarEnGestion.Text = "App Gestión"
        '
        'lblPublicarEnWeb
        '
        Me.lblPublicarEnWeb.AutoSize = True
        Me.lblPublicarEnWeb.Location = New System.Drawing.Point(4, 16)
        Me.lblPublicarEnWeb.Name = "lblPublicarEnWeb"
        Me.lblPublicarEnWeb.Size = New System.Drawing.Size(71, 13)
        Me.lblPublicarEnWeb.TabIndex = 0
        Me.lblPublicarEnWeb.Text = "Web / Carrito"
        '
        'chbFechaActualizado
        '
        Me.chbFechaActualizado.AutoSize = True
        Me.chbFechaActualizado.BindearPropiedadControl = Nothing
        Me.chbFechaActualizado.BindearPropiedadEntidad = Nothing
        Me.chbFechaActualizado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaActualizado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaActualizado.IsPK = False
        Me.chbFechaActualizado.IsRequired = False
        Me.chbFechaActualizado.Key = Nothing
        Me.chbFechaActualizado.LabelAsoc = Nothing
        Me.chbFechaActualizado.Location = New System.Drawing.Point(12, 163)
        Me.chbFechaActualizado.Name = "chbFechaActualizado"
        Me.chbFechaActualizado.Size = New System.Drawing.Size(114, 17)
        Me.chbFechaActualizado.TabIndex = 24
        Me.chbFechaActualizado.Text = "Fecha Actualizado"
        Me.chbFechaActualizado.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(360, 161)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 28
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(323, 165)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 27
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
        Me.dtpDesde.Location = New System.Drawing.Point(180, 161)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 26
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(136, 165)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 25
        Me.lblDesde.Text = "Desde"
        '
        'lblCodigoProducto
        '
        Me.lblCodigoProducto.AutoSize = True
        Me.lblCodigoProducto.LabelAsoc = Nothing
        Me.lblCodigoProducto.Location = New System.Drawing.Point(9, 118)
        Me.lblCodigoProducto.Name = "lblCodigoProducto"
        Me.lblCodigoProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProducto.TabIndex = 19
        Me.lblCodigoProducto.Text = "Codigo"
        '
        'txtCodigoProducto
        '
        Me.txtCodigoProducto.BindearPropiedadControl = Nothing
        Me.txtCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.txtCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoProducto.Formato = ""
        Me.txtCodigoProducto.IsDecimal = False
        Me.txtCodigoProducto.IsNumber = False
        Me.txtCodigoProducto.IsPK = False
        Me.txtCodigoProducto.IsRequired = False
        Me.txtCodigoProducto.Key = ""
        Me.txtCodigoProducto.LabelAsoc = Me.lblCodigoProducto
        Me.txtCodigoProducto.Location = New System.Drawing.Point(12, 134)
        Me.txtCodigoProducto.MaxLength = 15
        Me.txtCodigoProducto.Name = "txtCodigoProducto"
        Me.txtCodigoProducto.Size = New System.Drawing.Size(115, 20)
        Me.txtCodigoProducto.TabIndex = 22
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.LabelAsoc = Nothing
        Me.lblNombreProducto.Location = New System.Drawing.Point(130, 118)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblNombreProducto.TabIndex = 20
        Me.lblNombreProducto.Text = "Producto"
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.BindearPropiedadControl = Nothing
        Me.txtNombreProducto.BindearPropiedadEntidad = Nothing
        Me.txtNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreProducto.Formato = ""
        Me.txtNombreProducto.IsDecimal = False
        Me.txtNombreProducto.IsNumber = False
        Me.txtNombreProducto.IsPK = False
        Me.txtNombreProducto.IsRequired = False
        Me.txtNombreProducto.Key = ""
        Me.txtNombreProducto.LabelAsoc = Me.lblNombreProducto
        Me.txtNombreProducto.Location = New System.Drawing.Point(133, 134)
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.Size = New System.Drawing.Size(339, 20)
        Me.txtNombreProducto.TabIndex = 23
        '
        'lblSubRubro
        '
        Me.lblSubRubro.AutoSize = True
        Me.lblSubRubro.LabelAsoc = Nothing
        Me.lblSubRubro.Location = New System.Drawing.Point(350, 71)
        Me.lblSubRubro.Name = "lblSubRubro"
        Me.lblSubRubro.Size = New System.Drawing.Size(55, 13)
        Me.lblSubRubro.TabIndex = 12
        Me.lblSubRubro.Text = "SubRubro"
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.ConcatenarNombreRubro = False
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(411, 68)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(208, 21)
        Me.cmbSubRubro.TabIndex = 13
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(4, 71)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 10
        Me.lblRubro.Text = "Rubro"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.LabelAsoc = Nothing
        Me.lblMarca.Location = New System.Drawing.Point(4, 44)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 6
        Me.lblMarca.Text = "Marca"
        '
        'cmbRubro
        '
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Me.lblRubro
        Me.cmbRubro.Location = New System.Drawing.Point(97, 68)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(244, 21)
        Me.cmbRubro.TabIndex = 11
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Me.lblMarca
        Me.cmbMarca.Location = New System.Drawing.Point(97, 41)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(244, 21)
        Me.cmbMarca.TabIndex = 7
        '
        'cmbEsOferta
        '
        Me.cmbEsOferta.BindearPropiedadControl = ""
        Me.cmbEsOferta.BindearPropiedadEntidad = ""
        Me.cmbEsOferta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsOferta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsOferta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsOferta.FormattingEnabled = True
        Me.cmbEsOferta.IsPK = False
        Me.cmbEsOferta.IsRequired = False
        Me.cmbEsOferta.Items.AddRange(New Object() {"TODOS", "NO", "SI"})
        Me.cmbEsOferta.Key = Nothing
        Me.cmbEsOferta.LabelAsoc = Nothing
        Me.cmbEsOferta.Location = New System.Drawing.Point(411, 40)
        Me.cmbEsOferta.Name = "cmbEsOferta"
        Me.cmbEsOferta.Size = New System.Drawing.Size(82, 21)
        Me.cmbEsOferta.TabIndex = 9
        '
        'lblEsOferta
        '
        Me.lblEsOferta.AutoSize = True
        Me.lblEsOferta.LabelAsoc = Nothing
        Me.lblEsOferta.Location = New System.Drawing.Point(355, 45)
        Me.lblEsOferta.Name = "lblEsOferta"
        Me.lblEsOferta.Size = New System.Drawing.Size(51, 13)
        Me.lblEsOferta.TabIndex = 8
        Me.lblEsOferta.Text = "Es Oferta"
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.bscProducto2.Location = New System.Drawing.Point(233, 95)
        Me.bscProducto2.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(284, 20)
        Me.bscProducto2.TabIndex = 18
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(97, 95)
        Me.bscCodigoProducto2.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(130, 20)
        Me.bscCodigoProducto2.TabIndex = 17
        '
        'chbConStock
        '
        Me.chbConStock.AutoSize = True
        Me.chbConStock.BindearPropiedadControl = Nothing
        Me.chbConStock.BindearPropiedadEntidad = Nothing
        Me.chbConStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConStock.IsPK = False
        Me.chbConStock.IsRequired = False
        Me.chbConStock.Key = Nothing
        Me.chbConStock.LabelAsoc = Nothing
        Me.chbConStock.Location = New System.Drawing.Point(520, 16)
        Me.chbConStock.Name = "chbConStock"
        Me.chbConStock.Size = New System.Drawing.Size(76, 17)
        Me.chbConStock.TabIndex = 4
        Me.chbConStock.Text = "Con Stock"
        Me.chbConStock.UseVisualStyleBackColor = True
        '
        'chbConPrecio
        '
        Me.chbConPrecio.AutoSize = True
        Me.chbConPrecio.BindearPropiedadControl = Nothing
        Me.chbConPrecio.BindearPropiedadEntidad = Nothing
        Me.chbConPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConPrecio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConPrecio.IsPK = False
        Me.chbConPrecio.IsRequired = False
        Me.chbConPrecio.Key = Nothing
        Me.chbConPrecio.LabelAsoc = Nothing
        Me.chbConPrecio.Location = New System.Drawing.Point(355, 16)
        Me.chbConPrecio.Name = "chbConPrecio"
        Me.chbConPrecio.Size = New System.Drawing.Size(78, 17)
        Me.chbConPrecio.TabIndex = 2
        Me.chbConPrecio.Text = "Con Precio"
        Me.chbConPrecio.UseVisualStyleBackColor = True
        '
        'cmbListaDePrecios
        '
        Me.cmbListaDePrecios.BindearPropiedadControl = Nothing
        Me.cmbListaDePrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePrecios.FormattingEnabled = True
        Me.cmbListaDePrecios.IsPK = False
        Me.cmbListaDePrecios.IsRequired = False
        Me.cmbListaDePrecios.Key = Nothing
        Me.cmbListaDePrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaDePrecios.Location = New System.Drawing.Point(97, 14)
        Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
        Me.cmbListaDePrecios.Size = New System.Drawing.Size(244, 21)
        Me.cmbListaDePrecios.TabIndex = 1
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(4, 17)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 0
        Me.lblListaPrecios.Text = "Lista de Precios"
        '
        'chbConImagen
        '
        Me.chbConImagen.AutoSize = True
        Me.chbConImagen.BindearPropiedadControl = Nothing
        Me.chbConImagen.BindearPropiedadEntidad = Nothing
        Me.chbConImagen.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConImagen.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConImagen.IsPK = False
        Me.chbConImagen.IsRequired = False
        Me.chbConImagen.Key = Nothing
        Me.chbConImagen.LabelAsoc = Nothing
        Me.chbConImagen.Location = New System.Drawing.Point(434, 16)
        Me.chbConImagen.Name = "chbConImagen"
        Me.chbConImagen.Size = New System.Drawing.Size(83, 17)
        Me.chbConImagen.TabIndex = 3
        Me.chbConImagen.Text = "Con Imagen"
        Me.chbConImagen.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(867, 46)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(88, 45)
        Me.btnConsultar.TabIndex = 30
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.chbProducto.Location = New System.Drawing.Point(12, 97)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 16
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'pnlCodigoDescripcion
        '
        Me.pnlCodigoDescripcion.Controls.Add(Me.radCodigoYDescripcion)
        Me.pnlCodigoDescripcion.Controls.Add(Me.radCodigoODescripcion)
        Me.pnlCodigoDescripcion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlCodigoDescripcion.Location = New System.Drawing.Point(191, 112)
        Me.pnlCodigoDescripcion.Name = "pnlCodigoDescripcion"
        Me.pnlCodigoDescripcion.Size = New System.Drawing.Size(260, 18)
        Me.pnlCodigoDescripcion.TabIndex = 21
        Me.pnlCodigoDescripcion.TabStop = True
        '
        'radCodigoYDescripcion
        '
        Me.radCodigoYDescripcion.AutoSize = True
        Me.radCodigoYDescripcion.Checked = True
        Me.radCodigoYDescripcion.Location = New System.Drawing.Point(3, 3)
        Me.radCodigoYDescripcion.Name = "radCodigoYDescripcion"
        Me.radCodigoYDescripcion.Size = New System.Drawing.Size(127, 17)
        Me.radCodigoYDescripcion.TabIndex = 0
        Me.radCodigoYDescripcion.TabStop = True
        Me.radCodigoYDescripcion.Text = "Código Y Descripción"
        Me.radCodigoYDescripcion.UseVisualStyleBackColor = True
        '
        'radCodigoODescripcion
        '
        Me.radCodigoODescripcion.AutoSize = True
        Me.radCodigoODescripcion.Location = New System.Drawing.Point(136, 3)
        Me.radCodigoODescripcion.Name = "radCodigoODescripcion"
        Me.radCodigoODescripcion.Size = New System.Drawing.Size(128, 17)
        Me.radCodigoODescripcion.TabIndex = 1
        Me.radCodigoODescripcion.Text = "Código O Descripción"
        Me.radCodigoODescripcion.UseVisualStyleBackColor = True
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
        Me.chbConIVA.Location = New System.Drawing.Point(160, 230)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 2
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'chb2Columnas
        '
        Me.chb2Columnas.AutoSize = True
        Me.chb2Columnas.BindearPropiedadControl = Nothing
        Me.chb2Columnas.BindearPropiedadEntidad = Nothing
        Me.chb2Columnas.ForeColorFocus = System.Drawing.Color.Red
        Me.chb2Columnas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chb2Columnas.IsPK = False
        Me.chb2Columnas.IsRequired = False
        Me.chb2Columnas.Key = Nothing
        Me.chb2Columnas.LabelAsoc = Nothing
        Me.chb2Columnas.Location = New System.Drawing.Point(20, 230)
        Me.chb2Columnas.Name = "chb2Columnas"
        Me.chb2Columnas.Size = New System.Drawing.Size(134, 17)
        Me.chb2Columnas.TabIndex = 1
        Me.chb2Columnas.Text = "Imprimir en 2 Columnas"
        Me.chb2Columnas.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsbImprimir2, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
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
        Me.tsbImprimir.Size = New System.Drawing.Size(147, 26)
        Me.tsbImprimir.Text = "&Imprimir Prediseñado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir2
        '
        Me.tsbImprimir2.Image = CType(resources.GetObject("tsbImprimir2.Image"), System.Drawing.Image)
        Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir2.Name = "tsbImprimir2"
        Me.tsbImprimir2.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir2.Text = "&Imprimir"
        Me.tsbImprimir2.ToolTipText = "Imprimir"
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
        Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'rbRubroSubRubro
        '
        Me.rbRubroSubRubro.AutoSize = True
        Me.rbRubroSubRubro.Location = New System.Drawing.Point(192, 45)
        Me.rbRubroSubRubro.Name = "rbRubroSubRubro"
        Me.rbRubroSubRubro.Size = New System.Drawing.Size(108, 17)
        Me.rbRubroSubRubro.TabIndex = 5
        Me.rbRubroSubRubro.Text = "Rubro_SubRubro"
        Me.rbRubroSubRubro.UseVisualStyleBackColor = True
        '
        'rbSubRubro
        '
        Me.rbSubRubro.AutoSize = True
        Me.rbSubRubro.Location = New System.Drawing.Point(7, 68)
        Me.rbSubRubro.Name = "rbSubRubro"
        Me.rbSubRubro.Size = New System.Drawing.Size(73, 17)
        Me.rbSubRubro.TabIndex = 6
        Me.rbSubRubro.Text = "SubRubro"
        Me.rbSubRubro.UseVisualStyleBackColor = True
        '
        'rbMarcaRubroSubRubro
        '
        Me.rbMarcaRubroSubRubro.AutoSize = True
        Me.rbMarcaRubroSubRubro.Location = New System.Drawing.Point(192, 22)
        Me.rbMarcaRubroSubRubro.Name = "rbMarcaRubroSubRubro"
        Me.rbMarcaRubroSubRubro.Size = New System.Drawing.Size(144, 17)
        Me.rbMarcaRubroSubRubro.TabIndex = 2
        Me.rbMarcaRubroSubRubro.Text = "Marca_Rubro_SubRubro"
        Me.rbMarcaRubroSubRubro.UseVisualStyleBackColor = True
        '
        'gbAgruparPor
        '
        Me.gbAgruparPor.Controls.Add(Me.rbRubroSubRubroSubSubRubro)
        Me.gbAgruparPor.Controls.Add(Me.rbMarcaRubroSubRubro)
        Me.gbAgruparPor.Controls.Add(Me.optAgruparPorMarcaRubro)
        Me.gbAgruparPor.Controls.Add(Me.rbRubroSubRubro)
        Me.gbAgruparPor.Controls.Add(Me.optAgruparPorRubro)
        Me.gbAgruparPor.Controls.Add(Me.rbSubRubro)
        Me.gbAgruparPor.Controls.Add(Me.optAgruparPorRubroMarca)
        Me.gbAgruparPor.Controls.Add(Me.optAgruparPorMarca)
        Me.gbAgruparPor.Location = New System.Drawing.Point(8, 252)
        Me.gbAgruparPor.Name = "gbAgruparPor"
        Me.gbAgruparPor.Size = New System.Drawing.Size(383, 91)
        Me.gbAgruparPor.TabIndex = 3
        Me.gbAgruparPor.TabStop = False
        Me.gbAgruparPor.Text = "Agrupar Por..."
        '
        'rbRubroSubRubroSubSubRubro
        '
        Me.rbRubroSubRubroSubSubRubro.AutoSize = True
        Me.rbRubroSubRubroSubSubRubro.Location = New System.Drawing.Point(192, 68)
        Me.rbRubroSubRubroSubSubRubro.Name = "rbRubroSubRubroSubSubRubro"
        Me.rbRubroSubRubroSubSubRubro.Size = New System.Drawing.Size(181, 17)
        Me.rbRubroSubRubroSubSubRubro.TabIndex = 7
        Me.rbRubroSubRubroSubSubRubro.Text = "Rubro_SubRubro_SubSubRubro"
        Me.rbRubroSubRubroSubSubRubro.UseVisualStyleBackColor = True
        '
        'gbOrdenarPor
        '
        Me.gbOrdenarPor.Controls.Add(Me.rbCodNumerico)
        Me.gbOrdenarPor.Controls.Add(Me.optOrdenarPorCodigo)
        Me.gbOrdenarPor.Controls.Add(Me.optOrdenarPorNombre)
        Me.gbOrdenarPor.Location = New System.Drawing.Point(397, 252)
        Me.gbOrdenarPor.Name = "gbOrdenarPor"
        Me.gbOrdenarPor.Size = New System.Drawing.Size(95, 74)
        Me.gbOrdenarPor.TabIndex = 4
        Me.gbOrdenarPor.TabStop = False
        Me.gbOrdenarPor.Text = "Ordernar Por..."
        '
        'rbCodNumerico
        '
        Me.rbCodNumerico.AutoSize = True
        Me.rbCodNumerico.Location = New System.Drawing.Point(6, 51)
        Me.rbCodNumerico.Name = "rbCodNumerico"
        Me.rbCodNumerico.Size = New System.Drawing.Size(75, 17)
        Me.rbCodNumerico.TabIndex = 2
        Me.rbCodNumerico.Text = "Cód. Num."
        Me.rbCodNumerico.UseVisualStyleBackColor = True
        Me.rbCodNumerico.Visible = False
        '
        'ListaDePreciosParaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 556)
        Me.Controls.Add(Me.gbOrdenarPor)
        Me.Controls.Add(Me.chbCondensado)
        Me.Controls.Add(Me.gbAgruparPor)
        Me.Controls.Add(Me.grbMonedaCliente)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.chb2Columnas)
        Me.Controls.Add(Me.chbConIVA)
        Me.KeyPreview = True
        Me.Name = "ListaDePreciosParaClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emisión de Lista de Precios para Clientes"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbMonedaCliente.ResumeLayout(False)
        Me.grbMonedaCliente.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.grpPublicarEn.ResumeLayout(False)
        Me.grpPublicarEn.PerformLayout()
        Me.pnlCodigoDescripcion.ResumeLayout(False)
        Me.pnlCodigoDescripcion.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.gbAgruparPor.ResumeLayout(False)
        Me.gbAgruparPor.PerformLayout()
        Me.gbOrdenarPor.ResumeLayout(False)
        Me.gbOrdenarPor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents chbProducto As Eniac.Controles.CheckBox
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConsultar As Eniac.Controles.Button
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents chbConImagen As Eniac.Controles.CheckBox
    Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
    Friend WithEvents lblListaPrecios As Eniac.Controles.Label
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents optAgruparPorRubro As System.Windows.Forms.RadioButton
    Friend WithEvents optAgruparPorMarca As System.Windows.Forms.RadioButton
    Friend WithEvents chbConStock As Eniac.Controles.CheckBox
    Friend WithEvents chbConPrecio As Eniac.Controles.CheckBox
    Friend WithEvents grbMonedaCliente As System.Windows.Forms.GroupBox
    Friend WithEvents optOrdenarPorNombre As System.Windows.Forms.RadioButton
    Friend WithEvents optOrdenarPorCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents chbAgregarPrecioEmbalaje As Eniac.Controles.CheckBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chb2Columnas As Eniac.Controles.CheckBox
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents optAgruparPorMarcaRubro As System.Windows.Forms.RadioButton
    Friend WithEvents lblMoneda As Eniac.Controles.Label
    Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
    Friend WithEvents lblTipoCambio As Eniac.Controles.Label
    Friend WithEvents txtTipoCambio As Eniac.Controles.TextBox
    Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
    Friend WithEvents cmbEsOferta As Eniac.Controles.ComboBox
    Friend WithEvents lblEsOferta As Eniac.Controles.Label
    Friend WithEvents bscCliente2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoCliente2 As Eniac.Controles.Buscador2
    Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents chbCondensado As Eniac.Controles.CheckBox
    Friend WithEvents optAgruparPorRubroMarca As System.Windows.Forms.RadioButton
    Friend WithEvents cmbRubro As Eniac.Win.ComboBoxRubro
    Friend WithEvents cmbMarca As Eniac.Win.ComboBoxMarcas
    Friend WithEvents lblRubro As Eniac.Controles.Label
    Friend WithEvents lblMarca As Eniac.Controles.Label
    Friend WithEvents cmbSubRubro As Eniac.Win.ComboBoxSubRubro
    Friend WithEvents lblSubRubro As Eniac.Controles.Label
    Friend WithEvents pnlCodigoDescripcion As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents radCodigoYDescripcion As System.Windows.Forms.RadioButton
    Friend WithEvents radCodigoODescripcion As System.Windows.Forms.RadioButton
    Friend WithEvents lblCodigoProducto As Eniac.Controles.Label
    Friend WithEvents txtCodigoProducto As Eniac.Controles.TextBox
    Friend WithEvents lblNombreProducto As Eniac.Controles.Label
    Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
    Friend WithEvents chbFechaActualizado As Eniac.Controles.CheckBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
    Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents chbProductosCliente As Eniac.Controles.CheckBox
    Friend WithEvents cmbPrecio As Eniac.Controles.ComboBox
    Friend WithEvents lblPrecio As Eniac.Controles.Label
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpPublicarEn As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPublicarEnEmpresarial As Eniac.Controles.ComboBox
    Friend WithEvents cmbPublicarEnGestion As Eniac.Controles.ComboBox
    Friend WithEvents cmbPublicarEnWeb As Eniac.Controles.ComboBox
    Friend WithEvents lblPublicarEnEmpresarial As System.Windows.Forms.Label
    Friend WithEvents cmbPublicarEnSincronizarSucursal As Eniac.Controles.ComboBox
    Friend WithEvents lblPublicarEnSincronizacionSucursal As Eniac.Controles.Label
    Friend WithEvents cmbPublicarEnBalanza As Eniac.Controles.ComboBox
    Friend WithEvents lblPublicarEnBalanza As Eniac.Controles.Label
    Friend WithEvents cmbPublicarEnListaDePreciosParaClientes As Eniac.Controles.ComboBox
    Friend WithEvents lblPublicarEnListaDePreciosParaClientes As Eniac.Controles.Label
    Friend WithEvents lblPublicarEnGestion As System.Windows.Forms.Label
    Friend WithEvents lblPublicarEnWeb As System.Windows.Forms.Label
    Friend WithEvents rbRubroSubRubro As System.Windows.Forms.RadioButton
    Friend WithEvents rbSubRubro As System.Windows.Forms.RadioButton
    Friend WithEvents rbMarcaRubroSubRubro As System.Windows.Forms.RadioButton
    Friend WithEvents gbAgruparPor As System.Windows.Forms.GroupBox
    Friend WithEvents gbOrdenarPor As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSSubRubro As Eniac.Win.ComboBoxSubSubRubro
   Friend WithEvents lblSSubRubro As Eniac.Controles.Label
   Friend WithEvents rbCodNumerico As System.Windows.Forms.RadioButton
    Friend WithEvents rbRubroSubRubroSubSubRubro As RadioButton
End Class
