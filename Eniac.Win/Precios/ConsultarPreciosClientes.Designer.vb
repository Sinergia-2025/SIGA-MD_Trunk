<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarPreciosClientes
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Simbolo")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoSinIVA")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoConIVA")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaSinIVA")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaConIVA")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeBarras")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activo")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescRecProducto")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescRecProductoCalculado")
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
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdMarca")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Alicuota")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Simbolo")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioCostoSinIVA")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioCostoConIVA")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioVentaSinIVA")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioVentaConIVA")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdRubro")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaActualizacion")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSucursal")
      Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoDeBarras")
      Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Activo")
      Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescRecProducto")
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescRecProductoCalculado")
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
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
      Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
      Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
      Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
      Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
      Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargo")
      Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarPreciosClientes))
      Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tbcCliente = New System.Windows.Forms.TabControl()
      Me.tbpCliente = New System.Windows.Forms.TabPage()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
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
      Me.chbConPrecio = New Eniac.Controles.CheckBox()
      Me.chbConStock = New Eniac.Controles.CheckBox()
      Me.chbInactivos = New Eniac.Controles.CheckBox()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.cmbSucursales = New Eniac.Win.ComboBoxSucursales()
      Me.lblSucursales = New Eniac.Controles.Label()
      Me.cmbMoneda = New Eniac.Controles.ComboBox()
      Me.lblMoneda = New Eniac.Controles.Label()
      Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
      Me.lblCotizacionDolar = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.txtProducto = New Eniac.Controles.TextBox()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.lblCategoriaFiscal = New Eniac.Controles.Label()
      Me.txtCategoriaFiscal = New Eniac.Controles.TextBox()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.txtCategoria = New Eniac.Controles.TextBox()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.txtDescuentoRecargoPorc = New Eniac.Controles.TextBox()
      Me.lblDescuentoRecargoPorc = New Eniac.Controles.Label()
      Me.cmbListasDePreciosCliente = New Eniac.Controles.ComboBox()
      Me.lblListaDePreciosCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.tbpDescRecargos = New System.Windows.Forms.TabPage()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.dgvMarcaListasPrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.dgvMarcasDescuentos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tbpDescRecProductos = New System.Windows.Forms.TabPage()
      Me.ugdProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tbpDescRecSubRubros = New System.Windows.Forms.TabPage()
      Me.dgvSubrubroDesc = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.tbcCliente.SuspendLayout()
        Me.tbpCliente.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlModelos.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.pnlSubSubRubros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbCliente.SuspendLayout()
        Me.tbpDescRecargos.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvMarcaListasPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMarcasDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDescRecProductos.SuspendLayout()
        CType(Me.ugdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDescRecSubRubros.SuspendLayout()
        CType(Me.dgvSubrubroDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcCliente
        '
        Me.tbcCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcCliente.Controls.Add(Me.tbpCliente)
        Me.tbcCliente.Controls.Add(Me.tbpDescRecargos)
        Me.tbcCliente.Controls.Add(Me.tbpDescRecProductos)
        Me.tbcCliente.Controls.Add(Me.tbpDescRecSubRubros)
        Me.tbcCliente.Location = New System.Drawing.Point(5, 32)
        Me.tbcCliente.Name = "tbcCliente"
        Me.tbcCliente.SelectedIndex = 0
        Me.tbcCliente.Size = New System.Drawing.Size(977, 504)
        Me.tbcCliente.TabIndex = 0
        Me.tbcCliente.TabStop = False
        Me.tbcCliente.Tag = ""
        '
        'tbpCliente
        '
        Me.tbpCliente.BackColor = System.Drawing.Color.Transparent
        Me.tbpCliente.Controls.Add(Me.grbConsultar)
        Me.tbpCliente.Controls.Add(Me.grbCliente)
        Me.tbpCliente.Location = New System.Drawing.Point(4, 22)
        Me.tbpCliente.Name = "tbpCliente"
        Me.tbpCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCliente.Size = New System.Drawing.Size(969, 478)
        Me.tbpCliente.TabIndex = 0
        Me.tbpCliente.Text = "Cliente"
        Me.tbpCliente.UseVisualStyleBackColor = True
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.ugDetalle)
        Me.grbConsultar.Controls.Add(Me.TableLayoutPanel1)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbConsultar.Location = New System.Drawing.Point(3, 68)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(963, 407)
        Me.grbConsultar.TabIndex = 1
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar Precios"
        '
        'ugDetalle
        '
        Me.ugDetalle.DataSource = Me.UltraDataSource1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 12
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.Caption = "Marca"
        UltraGridColumn3.Header.VisiblePosition = 13
        UltraGridColumn3.Width = 140
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "Producto"
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn5.Header.Caption = "Nombre Producto"
        UltraGridColumn5.Header.VisiblePosition = 3
        UltraGridColumn5.Width = 286
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.Format = "N2"
        UltraGridColumn6.Header.Caption = "IVA"
        UltraGridColumn6.Header.VisiblePosition = 4
        UltraGridColumn6.Width = 40
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance4
        UltraGridColumn7.Header.Caption = "M."
        UltraGridColumn7.Header.VisiblePosition = 5
        UltraGridColumn7.Width = 40
        Appearance5.BackColor = System.Drawing.Color.Honeydew
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance5
        UltraGridColumn8.Format = "##,##0.00"
        UltraGridColumn8.Header.Caption = "P. COSTO"
        UltraGridColumn8.Header.VisiblePosition = 6
        UltraGridColumn8.Width = 80
        Appearance6.BackColor = System.Drawing.Color.Honeydew
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance6
        UltraGridColumn9.Format = "##,##0.00"
        UltraGridColumn9.Header.Caption = "P. COSTO"
        UltraGridColumn9.Header.VisiblePosition = 7
        UltraGridColumn9.Width = 80
        Appearance7.BackColor = System.Drawing.Color.Honeydew
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance7
        UltraGridColumn10.Format = "##,##0.00"
        UltraGridColumn10.Header.Caption = "P. VENTA"
        UltraGridColumn10.Header.VisiblePosition = 8
        UltraGridColumn10.Width = 80
        Appearance8.BackColor = System.Drawing.Color.Honeydew
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance8
        UltraGridColumn11.Format = "##,##0.00"
        UltraGridColumn11.Header.Caption = "P. VENTA"
        UltraGridColumn11.Header.VisiblePosition = 9
        UltraGridColumn11.Width = 80
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance9
        UltraGridColumn12.Format = "N2"
        UltraGridColumn12.Header.VisiblePosition = 10
        UltraGridColumn12.Width = 70
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.Caption = "Rubro"
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.Width = 140
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance10
        UltraGridColumn15.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn15.Header.Caption = "Actualizado"
        UltraGridColumn15.Header.VisiblePosition = 17
        UltraGridColumn15.Width = 100
        UltraGridColumn16.Header.Caption = "Sucursal"
        UltraGridColumn16.Header.VisiblePosition = 1
        UltraGridColumn16.Hidden = True
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance11
        UltraGridColumn17.Header.Caption = "Codigo de Barras"
        UltraGridColumn17.Header.VisiblePosition = 18
        UltraGridColumn17.Width = 100
        UltraGridColumn18.Header.VisiblePosition = 19
        UltraGridColumn18.Hidden = True
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance12
        UltraGridColumn21.Format = "##,##0.00"
        UltraGridColumn21.Header.Caption = "Desc/Rec Producto"
        UltraGridColumn21.Header.VisiblePosition = 16
        UltraGridColumn21.Width = 80
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance13
        UltraGridColumn29.Format = "N2"
        UltraGridColumn29.Header.Caption = "Desc/Rec Aplicado"
        UltraGridColumn29.Header.VisiblePosition = 11
        UltraGridColumn29.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn21, UltraGridColumn29})
        Appearance14.FontData.BoldAsString = "True"
        Appearance14.FontData.SizeInPoints = 6.0!
        UltraGridBand1.Header.Appearance = Appearance14
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastrar la columna que desea agrupar"
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
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Appearance22.BackColor2 = System.Drawing.Color.Transparent
        Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.BorderColor = System.Drawing.SystemColors.Window
        Appearance22.FontData.BoldAsString = "True"
        Appearance22.FontData.SizeInPoints = 9.0!
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance22
        Appearance23.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance23.BackColor2 = System.Drawing.Color.Silver
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
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
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 110)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(957, 294)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'UltraDataSource1
        '
        UltraDataColumn19.DataType = GetType(Decimal)
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20})
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBuscar, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(957, 94)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.chbConPrecio)
        Me.FlowLayoutPanel1.Controls.Add(Me.chbConStock)
        Me.FlowLayoutPanel1.Controls.Add(Me.chbInactivos)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 44)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(851, 51)
        Me.FlowLayoutPanel1.TabIndex = 1
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
        Me.pnlSubRubros.Location = New System.Drawing.Point(3, 24)
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
        Me.pnlSubSubRubros.Location = New System.Drawing.Point(274, 24)
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
        'chbConPrecio
        '
        Me.chbConPrecio.AutoSize = True
        Me.chbConPrecio.BindearPropiedadControl = Nothing
        Me.chbConPrecio.BindearPropiedadEntidad = Nothing
        Me.chbConPrecio.Checked = True
        Me.chbConPrecio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbConPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConPrecio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConPrecio.IsPK = False
        Me.chbConPrecio.IsRequired = False
        Me.chbConPrecio.Key = Nothing
        Me.chbConPrecio.LabelAsoc = Nothing
        Me.chbConPrecio.Location = New System.Drawing.Point(561, 24)
        Me.chbConPrecio.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.chbConPrecio.Name = "chbConPrecio"
        Me.chbConPrecio.Size = New System.Drawing.Size(78, 17)
        Me.chbConPrecio.TabIndex = 5
        Me.chbConPrecio.Text = "Con Precio"
        Me.chbConPrecio.UseVisualStyleBackColor = True
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
        Me.chbConStock.Location = New System.Drawing.Point(645, 24)
        Me.chbConStock.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.chbConStock.Name = "chbConStock"
        Me.chbConStock.Size = New System.Drawing.Size(76, 17)
        Me.chbConStock.TabIndex = 6
        Me.chbConStock.Text = "Con Stock"
        Me.chbConStock.UseVisualStyleBackColor = True
        '
        'chbInactivos
        '
        Me.chbInactivos.AutoSize = True
        Me.chbInactivos.BindearPropiedadControl = ""
        Me.chbInactivos.BindearPropiedadEntidad = ""
        Me.chbInactivos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbInactivos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbInactivos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbInactivos.IsPK = False
        Me.chbInactivos.IsRequired = False
        Me.chbInactivos.Key = Nothing
        Me.chbInactivos.LabelAsoc = Nothing
        Me.chbInactivos.Location = New System.Drawing.Point(727, 24)
        Me.chbInactivos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.chbInactivos.Name = "chbInactivos"
        Me.chbInactivos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbInactivos.Size = New System.Drawing.Size(69, 17)
        Me.chbInactivos.TabIndex = 7
        Me.chbInactivos.Text = "Inactivos"
        Me.chbInactivos.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Enabled = False
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(854, 47)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar (F3)"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.cmbSucursales)
        Me.Panel2.Controls.Add(Me.lblSucursales)
        Me.Panel2.Controls.Add(Me.cmbMoneda)
        Me.Panel2.Controls.Add(Me.lblMoneda)
        Me.Panel2.Controls.Add(Me.txtCotizacionDolar)
        Me.Panel2.Controls.Add(Me.lblCotizacionDolar)
        Me.Panel2.Controls.Add(Me.lblCodigo)
        Me.Panel2.Controls.Add(Me.txtCodigo)
        Me.Panel2.Controls.Add(Me.lblProducto)
        Me.Panel2.Controls.Add(Me.txtProducto)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(951, 38)
        Me.Panel2.TabIndex = 0
        '
        'cmbSucursales
        '
        Me.cmbSucursales.BindearPropiedadControl = Nothing
        Me.cmbSucursales.BindearPropiedadEntidad = Nothing
        Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.IsPK = False
        Me.cmbSucursales.IsRequired = False
        Me.cmbSucursales.Key = Nothing
        Me.cmbSucursales.LabelAsoc = Nothing
        Me.cmbSucursales.Location = New System.Drawing.Point(3, 14)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(173, 21)
        Me.cmbSucursales.TabIndex = 1
        '
        'lblSucursales
        '
        Me.lblSucursales.AutoSize = True
        Me.lblSucursales.LabelAsoc = Nothing
        Me.lblSucursales.Location = New System.Drawing.Point(3, -1)
        Me.lblSucursales.Name = "lblSucursales"
        Me.lblSucursales.Size = New System.Drawing.Size(59, 13)
        Me.lblSucursales.TabIndex = 0
        Me.lblSucursales.Text = "Sucursales"
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
        Me.cmbMoneda.Location = New System.Drawing.Point(728, 14)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(127, 21)
        Me.cmbMoneda.TabIndex = 7
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(582, 18)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(139, 13)
        Me.lblMoneda.TabIndex = 6
        Me.lblMoneda.Text = "Precio Utilizando la Moneda"
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BackColor = System.Drawing.SystemColors.Window
        Me.txtCotizacionDolar.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolar.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = "N2"
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(897, 14)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(48, 20)
        Me.txtCotizacionDolar.TabIndex = 9
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(863, 15)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(33, 18)
        Me.lblCotizacionDolar.TabIndex = 8
        Me.lblCotizacionDolar.Text = "Dolar"
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(212, -1)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = Nothing
        Me.txtCodigo.BindearPropiedadEntidad = Nothing
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = False
        Me.txtCodigo.IsPK = False
        Me.txtCodigo.IsRequired = False
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(215, 14)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(115, 20)
        Me.txtCodigo.TabIndex = 3
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(334, -1)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 4
        Me.lblProducto.Text = "Producto"
        '
        'txtProducto
        '
        Me.txtProducto.BindearPropiedadControl = Nothing
        Me.txtProducto.BindearPropiedadEntidad = Nothing
        Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProducto.Formato = ""
        Me.txtProducto.IsDecimal = False
        Me.txtProducto.IsNumber = False
        Me.txtProducto.IsPK = False
        Me.txtProducto.IsRequired = False
        Me.txtProducto.Key = ""
        Me.txtProducto.LabelAsoc = Me.lblProducto
        Me.txtProducto.Location = New System.Drawing.Point(337, 14)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(239, 20)
        Me.txtProducto.TabIndex = 5
        '
        'grbCliente
        '
        Me.grbCliente.Controls.Add(Me.lblCategoriaFiscal)
        Me.grbCliente.Controls.Add(Me.txtCategoriaFiscal)
        Me.grbCliente.Controls.Add(Me.lblCategoria)
        Me.grbCliente.Controls.Add(Me.txtCategoria)
        Me.grbCliente.Controls.Add(Me.bscCliente)
        Me.grbCliente.Controls.Add(Me.txtDescuentoRecargoPorc)
        Me.grbCliente.Controls.Add(Me.lblDescuentoRecargoPorc)
        Me.grbCliente.Controls.Add(Me.cmbListasDePreciosCliente)
        Me.grbCliente.Controls.Add(Me.lblListaDePreciosCliente)
        Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
        Me.grbCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbCliente.Location = New System.Drawing.Point(3, 3)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(963, 65)
        Me.grbCliente.TabIndex = 0
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Cliente"
        '
        'lblCategoriaFiscal
        '
        Me.lblCategoriaFiscal.AutoSize = True
        Me.lblCategoriaFiscal.LabelAsoc = Nothing
        Me.lblCategoriaFiscal.Location = New System.Drawing.Point(36, 45)
        Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
        Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
        Me.lblCategoriaFiscal.TabIndex = 2
        Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
        '
        'txtCategoriaFiscal
        '
        Me.txtCategoriaFiscal.BindearPropiedadControl = Nothing
        Me.txtCategoriaFiscal.BindearPropiedadEntidad = Nothing
        Me.txtCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoriaFiscal.Formato = ""
        Me.txtCategoriaFiscal.IsDecimal = False
        Me.txtCategoriaFiscal.IsNumber = False
        Me.txtCategoriaFiscal.IsPK = False
        Me.txtCategoriaFiscal.IsRequired = False
        Me.txtCategoriaFiscal.Key = ""
        Me.txtCategoriaFiscal.LabelAsoc = Me.lblCategoriaFiscal
        Me.txtCategoriaFiscal.Location = New System.Drawing.Point(123, 41)
        Me.txtCategoriaFiscal.Name = "txtCategoriaFiscal"
        Me.txtCategoriaFiscal.ReadOnly = True
        Me.txtCategoriaFiscal.Size = New System.Drawing.Size(169, 20)
        Me.txtCategoriaFiscal.TabIndex = 3
        Me.txtCategoriaFiscal.TabStop = False
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.LabelAsoc = Nothing
        Me.lblCategoria.Location = New System.Drawing.Point(310, 45)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lblCategoria.TabIndex = 4
        Me.lblCategoria.Text = "Categoria"
        '
        'txtCategoria
        '
        Me.txtCategoria.BindearPropiedadControl = Nothing
        Me.txtCategoria.BindearPropiedadEntidad = Nothing
        Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoria.Formato = ""
        Me.txtCategoria.IsDecimal = False
        Me.txtCategoria.IsNumber = False
        Me.txtCategoria.IsPK = False
        Me.txtCategoria.IsRequired = False
        Me.txtCategoria.Key = ""
        Me.txtCategoria.LabelAsoc = Me.lblCategoria
        Me.txtCategoria.Location = New System.Drawing.Point(368, 41)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(169, 20)
        Me.txtCategoria.TabIndex = 5
        Me.txtCategoria.TabStop = False
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(133, 17)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 1
        '
        'txtDescuentoRecargoPorc
        '
        Me.txtDescuentoRecargoPorc.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargoPorc.BindearPropiedadEntidad = "DescuentoRecargoPorc"
        Me.txtDescuentoRecargoPorc.Enabled = False
        Me.txtDescuentoRecargoPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc.IsDecimal = True
        Me.txtDescuentoRecargoPorc.IsNumber = True
        Me.txtDescuentoRecargoPorc.IsPK = False
        Me.txtDescuentoRecargoPorc.IsRequired = False
        Me.txtDescuentoRecargoPorc.Key = ""
        Me.txtDescuentoRecargoPorc.LabelAsoc = Me.lblDescuentoRecargoPorc
        Me.txtDescuentoRecargoPorc.Location = New System.Drawing.Point(867, 40)
        Me.txtDescuentoRecargoPorc.MaxLength = 6
        Me.txtDescuentoRecargoPorc.Name = "txtDescuentoRecargoPorc"
        Me.txtDescuentoRecargoPorc.ReadOnly = True
        Me.txtDescuentoRecargoPorc.Size = New System.Drawing.Size(56, 20)
        Me.txtDescuentoRecargoPorc.TabIndex = 9
        Me.txtDescuentoRecargoPorc.Text = "0.00"
        Me.txtDescuentoRecargoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargoPorc
        '
        Me.lblDescuentoRecargoPorc.AutoSize = True
        Me.lblDescuentoRecargoPorc.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc.Location = New System.Drawing.Point(776, 44)
        Me.lblDescuentoRecargoPorc.Name = "lblDescuentoRecargoPorc"
        Me.lblDescuentoRecargoPorc.Size = New System.Drawing.Size(87, 13)
        Me.lblDescuentoRecargoPorc.TabIndex = 8
        Me.lblDescuentoRecargoPorc.Text = "Desc. / Recargo"
        '
        'cmbListasDePreciosCliente
        '
        Me.cmbListasDePreciosCliente.BindearPropiedadControl = ""
        Me.cmbListasDePreciosCliente.BindearPropiedadEntidad = ""
        Me.cmbListasDePreciosCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListasDePreciosCliente.Enabled = False
        Me.cmbListasDePreciosCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListasDePreciosCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListasDePreciosCliente.FormattingEnabled = True
        Me.cmbListasDePreciosCliente.IsPK = False
        Me.cmbListasDePreciosCliente.IsRequired = True
        Me.cmbListasDePreciosCliente.Key = Nothing
        Me.cmbListasDePreciosCliente.LabelAsoc = Me.lblListaDePreciosCliente
        Me.cmbListasDePreciosCliente.Location = New System.Drawing.Point(560, 41)
        Me.cmbListasDePreciosCliente.Name = "cmbListasDePreciosCliente"
        Me.cmbListasDePreciosCliente.Size = New System.Drawing.Size(204, 21)
        Me.cmbListasDePreciosCliente.TabIndex = 7
        '
        'lblListaDePreciosCliente
        '
        Me.lblListaDePreciosCliente.AutoSize = True
        Me.lblListaDePreciosCliente.LabelAsoc = Nothing
        Me.lblListaDePreciosCliente.Location = New System.Drawing.Point(557, 23)
        Me.lblListaDePreciosCliente.Name = "lblListaDePreciosCliente"
        Me.lblListaDePreciosCliente.Size = New System.Drawing.Size(82, 13)
        Me.lblListaDePreciosCliente.TabIndex = 6
        Me.lblListaDePreciosCliente.Text = "Lista de Precios"
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
        Me.bscCodigoCliente.IsNumber = True
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(39, 17)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 0
        '
        'tbpDescRecargos
        '
        Me.tbpDescRecargos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbpDescRecargos.Controls.Add(Me.SplitContainer1)
        Me.tbpDescRecargos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDescRecargos.Name = "tbpDescRecargos"
        Me.tbpDescRecargos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDescRecargos.Size = New System.Drawing.Size(969, 478)
        Me.tbpDescRecargos.TabIndex = 1
        Me.tbpDescRecargos.Text = "Descuentos/Recargos por Marcas/Listas Precios"
        Me.tbpDescRecargos.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvMarcaListasPrecios)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvMarcasDescuentos)
        Me.SplitContainer1.Size = New System.Drawing.Size(963, 472)
        Me.SplitContainer1.SplitterDistance = 500
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 21
        '
        'dgvMarcaListasPrecios
        '
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvMarcaListasPrecios.DisplayLayout.Appearance = Appearance26
        UltraGridColumn25.Header.VisiblePosition = 0
        UltraGridColumn25.Hidden = True
        UltraGridColumn34.Header.Caption = "Cliente"
        UltraGridColumn34.Header.VisiblePosition = 1
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 265
        UltraGridColumn35.Header.VisiblePosition = 2
        UltraGridColumn35.Hidden = True
        UltraGridColumn36.Header.Caption = "Marca"
        UltraGridColumn36.Header.VisiblePosition = 3
        UltraGridColumn36.Width = 250
        UltraGridColumn37.Header.VisiblePosition = 4
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.Header.Caption = "Lista Precios"
        UltraGridColumn38.Header.VisiblePosition = 5
        UltraGridColumn38.Width = 243
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn25, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38})
        Appearance27.FontData.BoldAsString = "True"
        Appearance27.FontData.SizeInPoints = 6.0!
        UltraGridBand2.Header.Appearance = Appearance27
        Me.dgvMarcaListasPrecios.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.dgvMarcaListasPrecios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.dgvMarcaListasPrecios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance28.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvMarcaListasPrecios.DisplayLayout.GroupByBox.Appearance = Appearance28
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvMarcaListasPrecios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance29
        Me.dgvMarcaListasPrecios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvMarcaListasPrecios.DisplayLayout.GroupByBox.Hidden = True
        Me.dgvMarcaListasPrecios.DisplayLayout.GroupByBox.Prompt = "Arrastrar la columna que desea agrupar"
        Appearance30.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance30.BackColor2 = System.Drawing.SystemColors.Control
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvMarcaListasPrecios.DisplayLayout.GroupByBox.PromptAppearance = Appearance30
        Me.dgvMarcaListasPrecios.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvMarcaListasPrecios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Appearance31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.ActiveCellAppearance = Appearance31
        Appearance32.BackColor = System.Drawing.SystemColors.Highlight
        Appearance32.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.ActiveRowAppearance = Appearance32
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.CardAreaAppearance = Appearance33
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Appearance34.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.CellAppearance = Appearance34
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.CellPadding = 0
        Appearance35.BackColor = System.Drawing.Color.Transparent
        Appearance35.BackColor2 = System.Drawing.Color.Transparent
        Appearance35.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance35.BorderColor = System.Drawing.SystemColors.Window
        Appearance35.FontData.BoldAsString = "True"
        Appearance35.FontData.SizeInPoints = 9.0!
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.GroupByRowAppearance = Appearance35
        Appearance36.TextHAlignAsString = "Left"
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.HeaderAppearance = Appearance36
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Appearance37.BorderColor = System.Drawing.Color.Silver
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.RowAppearance = Appearance37
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvMarcaListasPrecios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance38
        Me.dgvMarcaListasPrecios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvMarcaListasPrecios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvMarcaListasPrecios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvMarcaListasPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMarcaListasPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMarcaListasPrecios.Location = New System.Drawing.Point(0, 0)
        Me.dgvMarcaListasPrecios.Name = "dgvMarcaListasPrecios"
        Me.dgvMarcaListasPrecios.Size = New System.Drawing.Size(500, 472)
        Me.dgvMarcaListasPrecios.TabIndex = 19
        Me.dgvMarcaListasPrecios.Text = "UltraGrid1"
        '
        'dgvMarcasDescuentos
        '
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Appearance39.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvMarcasDescuentos.DisplayLayout.Appearance = Appearance39
        UltraGridColumn26.Header.VisiblePosition = 0
        UltraGridColumn26.Hidden = True
        UltraGridColumn41.Header.Caption = "Cliente"
        UltraGridColumn41.Header.VisiblePosition = 1
        UltraGridColumn41.Hidden = True
        UltraGridColumn41.Width = 265
        UltraGridColumn42.Header.VisiblePosition = 2
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.Header.Caption = "Marca"
        UltraGridColumn43.Header.VisiblePosition = 3
        UltraGridColumn43.Width = 250
        Appearance40.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance40
        UltraGridColumn44.Format = "N2"
        UltraGridColumn44.Header.Caption = "D/R %1"
        UltraGridColumn44.Header.VisiblePosition = 4
        UltraGridColumn44.Width = 59
        Appearance41.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance41
        UltraGridColumn45.Format = "N2"
        UltraGridColumn45.Header.Caption = "D/R %2"
        UltraGridColumn45.Header.VisiblePosition = 5
        UltraGridColumn45.Width = 55
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn26, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45})
        Appearance42.FontData.BoldAsString = "True"
        Appearance42.FontData.SizeInPoints = 6.0!
        UltraGridBand3.Header.Appearance = Appearance42
        Me.dgvMarcasDescuentos.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.dgvMarcasDescuentos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.dgvMarcasDescuentos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance43.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance43.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance43.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvMarcasDescuentos.DisplayLayout.GroupByBox.Appearance = Appearance43
        Appearance44.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvMarcasDescuentos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance44
        Me.dgvMarcasDescuentos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvMarcasDescuentos.DisplayLayout.GroupByBox.Hidden = True
        Me.dgvMarcasDescuentos.DisplayLayout.GroupByBox.Prompt = "Arrastrar la columna que desea agrupar"
        Appearance45.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance45.BackColor2 = System.Drawing.SystemColors.Control
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvMarcasDescuentos.DisplayLayout.GroupByBox.PromptAppearance = Appearance45
        Me.dgvMarcasDescuentos.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvMarcasDescuentos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMarcasDescuentos.DisplayLayout.Override.ActiveCellAppearance = Appearance46
        Appearance47.BackColor = System.Drawing.SystemColors.Highlight
        Appearance47.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvMarcasDescuentos.DisplayLayout.Override.ActiveRowAppearance = Appearance47
        Me.dgvMarcasDescuentos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvMarcasDescuentos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvMarcasDescuentos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvMarcasDescuentos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvMarcasDescuentos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvMarcasDescuentos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance48.BackColor = System.Drawing.SystemColors.Window
        Me.dgvMarcasDescuentos.DisplayLayout.Override.CardAreaAppearance = Appearance48
        Appearance49.BorderColor = System.Drawing.Color.Silver
        Appearance49.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvMarcasDescuentos.DisplayLayout.Override.CellAppearance = Appearance49
        Me.dgvMarcasDescuentos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvMarcasDescuentos.DisplayLayout.Override.CellPadding = 0
        Appearance50.BackColor = System.Drawing.Color.Transparent
        Appearance50.BackColor2 = System.Drawing.Color.Transparent
        Appearance50.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Appearance50.FontData.BoldAsString = "True"
        Appearance50.FontData.SizeInPoints = 9.0!
        Me.dgvMarcasDescuentos.DisplayLayout.Override.GroupByRowAppearance = Appearance50
        Appearance51.TextHAlignAsString = "Left"
        Me.dgvMarcasDescuentos.DisplayLayout.Override.HeaderAppearance = Appearance51
        Me.dgvMarcasDescuentos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvMarcasDescuentos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Appearance52.BorderColor = System.Drawing.Color.Silver
        Me.dgvMarcasDescuentos.DisplayLayout.Override.RowAppearance = Appearance52
        Me.dgvMarcasDescuentos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance53.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvMarcasDescuentos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance53
        Me.dgvMarcasDescuentos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvMarcasDescuentos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvMarcasDescuentos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvMarcasDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMarcasDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMarcasDescuentos.Location = New System.Drawing.Point(0, 0)
        Me.dgvMarcasDescuentos.Name = "dgvMarcasDescuentos"
        Me.dgvMarcasDescuentos.Size = New System.Drawing.Size(462, 472)
        Me.dgvMarcasDescuentos.TabIndex = 20
        Me.dgvMarcasDescuentos.Text = "UltraGrid1"
        '
        'tbpDescRecProductos
        '
        Me.tbpDescRecProductos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDescRecProductos.Controls.Add(Me.ugdProductos)
        Me.tbpDescRecProductos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDescRecProductos.Name = "tbpDescRecProductos"
        Me.tbpDescRecProductos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDescRecProductos.Size = New System.Drawing.Size(969, 478)
        Me.tbpDescRecProductos.TabIndex = 2
        Me.tbpDescRecProductos.Text = "Descuentos/Recargos por Productos"
        '
        'ugdProductos
        '
        Appearance54.BackColor = System.Drawing.SystemColors.Window
        Appearance54.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugdProductos.DisplayLayout.Appearance = Appearance54
        UltraGridColumn46.Header.VisiblePosition = 0
        UltraGridColumn46.Hidden = True
        UltraGridColumn27.Header.Caption = "Cliente"
        UltraGridColumn27.Header.VisiblePosition = 1
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 265
        Appearance55.TextHAlignAsString = "Right"
        UltraGridColumn47.CellAppearance = Appearance55
        UltraGridColumn47.Header.Caption = "Codigo"
        UltraGridColumn47.Header.VisiblePosition = 2
        UltraGridColumn47.Width = 100
        UltraGridColumn48.Header.Caption = "Producto"
        UltraGridColumn48.Header.VisiblePosition = 3
        UltraGridColumn48.Width = 300
        Appearance56.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance56
        UltraGridColumn30.Format = "N2"
        UltraGridColumn30.Header.Caption = "D/R %1"
        UltraGridColumn30.Header.VisiblePosition = 4
        UltraGridColumn30.Width = 66
        Appearance57.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance57
        UltraGridColumn31.Format = "N2"
        UltraGridColumn31.Header.Caption = "D/R %2"
        UltraGridColumn31.Header.VisiblePosition = 5
        UltraGridColumn31.Width = 63
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn46, UltraGridColumn27, UltraGridColumn47, UltraGridColumn48, UltraGridColumn30, UltraGridColumn31})
        Appearance58.FontData.BoldAsString = "True"
        Appearance58.FontData.SizeInPoints = 6.0!
        UltraGridBand4.Header.Appearance = Appearance58
        Me.ugdProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.ugdProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.ugdProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance59.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance59.BorderColor = System.Drawing.SystemColors.Window
        Me.ugdProductos.DisplayLayout.GroupByBox.Appearance = Appearance59
        Appearance60.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance60
        Me.ugdProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugdProductos.DisplayLayout.GroupByBox.Hidden = True
        Me.ugdProductos.DisplayLayout.GroupByBox.Prompt = "Arrastrar la columna que desea agrupar"
        Appearance61.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance61.BackColor2 = System.Drawing.SystemColors.Control
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance61.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance61
        Me.ugdProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugdProductos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance62.BackColor = System.Drawing.SystemColors.Window
        Appearance62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugdProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance62
        Appearance63.BackColor = System.Drawing.SystemColors.Highlight
        Appearance63.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugdProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance63
        Me.ugdProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdProductos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugdProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugdProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Me.ugdProductos.DisplayLayout.Override.CardAreaAppearance = Appearance64
        Appearance65.BorderColor = System.Drawing.Color.Silver
        Appearance65.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugdProductos.DisplayLayout.Override.CellAppearance = Appearance65
        Me.ugdProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugdProductos.DisplayLayout.Override.CellPadding = 0
        Appearance66.BackColor = System.Drawing.Color.Transparent
        Appearance66.BackColor2 = System.Drawing.Color.Transparent
        Appearance66.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance66.BorderColor = System.Drawing.SystemColors.Window
        Appearance66.FontData.BoldAsString = "True"
        Appearance66.FontData.SizeInPoints = 9.0!
        Me.ugdProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance66
        Appearance67.TextHAlignAsString = "Left"
        Me.ugdProductos.DisplayLayout.Override.HeaderAppearance = Appearance67
        Me.ugdProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugdProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance68.BackColor = System.Drawing.SystemColors.Window
        Appearance68.BorderColor = System.Drawing.Color.Silver
        Me.ugdProductos.DisplayLayout.Override.RowAppearance = Appearance68
        Me.ugdProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance69.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugdProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance69
        Me.ugdProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugdProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugdProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugdProductos.Location = New System.Drawing.Point(3, 3)
        Me.ugdProductos.Name = "ugdProductos"
        Me.ugdProductos.Size = New System.Drawing.Size(963, 472)
        Me.ugdProductos.TabIndex = 21
        Me.ugdProductos.Text = "UltraGrid1"
        '
        'tbpDescRecSubRubros
        '
        Me.tbpDescRecSubRubros.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDescRecSubRubros.Controls.Add(Me.dgvSubrubroDesc)
        Me.tbpDescRecSubRubros.Location = New System.Drawing.Point(4, 22)
        Me.tbpDescRecSubRubros.Name = "tbpDescRecSubRubros"
        Me.tbpDescRecSubRubros.Size = New System.Drawing.Size(969, 478)
        Me.tbpDescRecSubRubros.TabIndex = 3
        Me.tbpDescRecSubRubros.Text = "Descuentos/Recargos por SubRubros"
        '
        'dgvSubrubroDesc
        '
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Appearance70.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvSubrubroDesc.DisplayLayout.Appearance = Appearance70
        UltraGridColumn28.Header.VisiblePosition = 0
        UltraGridColumn28.Hidden = True
        UltraGridColumn19.Header.VisiblePosition = 1
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.Header.Caption = "Rubro"
        UltraGridColumn20.Header.VisiblePosition = 2
        UltraGridColumn20.Width = 200
        Appearance71.TextHAlignAsString = "Center"
        UltraGridColumn22.CellAppearance = Appearance71
        UltraGridColumn22.Header.Caption = "Codigo"
        UltraGridColumn22.Header.VisiblePosition = 3
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 60
        UltraGridColumn23.Header.Caption = "SubRubro"
        UltraGridColumn23.Header.VisiblePosition = 4
        UltraGridColumn23.Width = 350
        Appearance72.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance72
        UltraGridColumn24.Format = "N2"
        UltraGridColumn24.Header.Caption = "Desc/Rec"
        UltraGridColumn24.Header.VisiblePosition = 5
        UltraGridColumn24.Width = 59
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn28, UltraGridColumn19, UltraGridColumn20, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24})
        Appearance73.FontData.BoldAsString = "True"
        Appearance73.FontData.SizeInPoints = 6.0!
        UltraGridBand5.Header.Appearance = Appearance73
        Me.dgvSubrubroDesc.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.dgvSubrubroDesc.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.dgvSubrubroDesc.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance74.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance74.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance74.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvSubrubroDesc.DisplayLayout.GroupByBox.Appearance = Appearance74
        Appearance75.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvSubrubroDesc.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance75
        Me.dgvSubrubroDesc.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvSubrubroDesc.DisplayLayout.GroupByBox.Hidden = True
        Me.dgvSubrubroDesc.DisplayLayout.GroupByBox.Prompt = "Arrastrar la columna que desea agrupar"
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance76.BackColor2 = System.Drawing.SystemColors.Control
        Appearance76.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance76.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvSubrubroDesc.DisplayLayout.GroupByBox.PromptAppearance = Appearance76
        Me.dgvSubrubroDesc.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvSubrubroDesc.DisplayLayout.MaxRowScrollRegions = 1
        Appearance77.BackColor = System.Drawing.SystemColors.Window
        Appearance77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvSubrubroDesc.DisplayLayout.Override.ActiveCellAppearance = Appearance77
        Appearance78.BackColor = System.Drawing.SystemColors.Highlight
        Appearance78.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvSubrubroDesc.DisplayLayout.Override.ActiveRowAppearance = Appearance78
        Me.dgvSubrubroDesc.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvSubrubroDesc.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvSubrubroDesc.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvSubrubroDesc.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvSubrubroDesc.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvSubrubroDesc.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance79.BackColor = System.Drawing.SystemColors.Window
        Me.dgvSubrubroDesc.DisplayLayout.Override.CardAreaAppearance = Appearance79
        Appearance80.BorderColor = System.Drawing.Color.Silver
        Appearance80.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvSubrubroDesc.DisplayLayout.Override.CellAppearance = Appearance80
        Me.dgvSubrubroDesc.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvSubrubroDesc.DisplayLayout.Override.CellPadding = 0
        Appearance81.BackColor = System.Drawing.Color.Transparent
        Appearance81.BackColor2 = System.Drawing.Color.Transparent
        Appearance81.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance81.BorderColor = System.Drawing.SystemColors.Window
        Appearance81.FontData.BoldAsString = "True"
        Appearance81.FontData.SizeInPoints = 9.0!
        Me.dgvSubrubroDesc.DisplayLayout.Override.GroupByRowAppearance = Appearance81
        Appearance82.TextHAlignAsString = "Left"
        Me.dgvSubrubroDesc.DisplayLayout.Override.HeaderAppearance = Appearance82
        Me.dgvSubrubroDesc.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvSubrubroDesc.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Appearance83.BorderColor = System.Drawing.Color.Silver
        Me.dgvSubrubroDesc.DisplayLayout.Override.RowAppearance = Appearance83
        Me.dgvSubrubroDesc.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance84.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvSubrubroDesc.DisplayLayout.Override.TemplateAddRowAppearance = Appearance84
        Me.dgvSubrubroDesc.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvSubrubroDesc.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvSubrubroDesc.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvSubrubroDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubrubroDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSubrubroDesc.Location = New System.Drawing.Point(0, 0)
        Me.dgvSubrubroDesc.Name = "dgvSubrubroDesc"
        Me.dgvSubrubroDesc.Size = New System.Drawing.Size(969, 478)
        Me.dgvSubrubroDesc.TabIndex = 22
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 1
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
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir})
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
        Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance85.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance85.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance85.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance85
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
        'ConsultarPreciosClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.tbcCliente)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ConsultarPreciosClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Precios por Cliente"
        Me.tbcCliente.ResumeLayout(False)
        Me.tbpCliente.ResumeLayout(False)
        Me.grbConsultar.ResumeLayout(False)
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.tbpDescRecargos.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvMarcaListasPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMarcasDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDescRecProductos.ResumeLayout(False)
        CType(Me.ugdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDescRecSubRubros.ResumeLayout(False)
        CType(Me.dgvSubrubroDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
    Friend WithEvents lblProducto As Eniac.Controles.Label
    Friend WithEvents txtProducto As Eniac.Controles.TextBox
    Friend WithEvents btnBuscar As Eniac.Controles.Button
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCodigo As Eniac.Controles.Label
    Friend WithEvents txtCodigo As Eniac.Controles.TextBox
    Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents cmbListasDePreciosCliente As Eniac.Controles.ComboBox
   Friend WithEvents lblListaDePreciosCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents txtDescuentoRecargoPorc As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargoPorc As Eniac.Controles.Label
   Friend WithEvents dgvMarcaListasPrecios As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents dgvMarcasDescuentos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tbcCliente As System.Windows.Forms.TabControl
   Friend WithEvents tbpCliente As System.Windows.Forms.TabPage
   Friend WithEvents tbpDescRecargos As System.Windows.Forms.TabPage
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents txtCategoriaFiscal As Eniac.Controles.TextBox
   Friend WithEvents lblCategoria As Eniac.Controles.Label
   Friend WithEvents txtCategoria As Eniac.Controles.TextBox
   Friend WithEvents txtCotizacionDolar As Eniac.Controles.TextBox
   Friend WithEvents lblCotizacionDolar As Eniac.Controles.Label
    Friend WithEvents tbpDescRecProductos As System.Windows.Forms.TabPage
    Friend WithEvents ugdProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tbpDescRecSubRubros As System.Windows.Forms.TabPage
   Friend WithEvents dgvSubrubroDesc As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
   Friend WithEvents lblMoneda As Eniac.Controles.Label
    Public WithEvents tsbPreferencias As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As ToolStripMenuItem
    Friend WithEvents tsmiAPDF As ToolStripMenuItem
    Friend WithEvents sfdExportar As SaveFileDialog
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
    Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
   Friend WithEvents cmbSucursales As ComboBoxSucursales
   Friend WithEvents lblSucursales As Controles.Label
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents Panel2 As Panel
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
   Friend WithEvents chbConPrecio As Controles.CheckBox
   Friend WithEvents chbConStock As Controles.CheckBox
   Friend WithEvents chbInactivos As Controles.CheckBox
End Class
